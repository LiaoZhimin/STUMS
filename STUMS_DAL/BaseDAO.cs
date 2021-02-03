
namespace STUMS_DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Linq.Expressions;
    public partial class BaseDAO<T> where T : class, new()
    {
        public MyDBContext dbContext = MyDBContextFactory.Create();

        #region 增删改

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        public void Add(T t)
        {
            dbContext.Set<T>().Add(t);
        }

        /// <summary>
        /// 删除，需要SaveChanges()才会保存到数据库
        /// </summary>
        /// <param name="t"></param>
        public void Delete(T t)
        {
            dbContext.Set<T>().Remove(t);
        }

        /// <summary>
        /// 修改，需要SaveChanges()才会保存到数据库
        /// </summary>
        /// <param name="t"></param>
        public void Update(T t)
        {
            dbContext.Set<T>().AddOrUpdate(t);
        }

        /// <summary>
        /// 保存更改，在增删改后，需要执行该函数，才会更新到数据库
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 先检验是否存在，存在则修改，否在 新增
        /// </summary>
        /// <param name="t"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public bool AddOrUpdateToSave(T t, Expression<Func<T, bool>> whereLambda)
        {
            if(Exists(whereLambda)) // 存在,修改
            {
                Update(t);
            }else // 不存在，新增
            {
                Add(t);
            }
            return SaveChanges();
        }

        /// <summary>
        /// 每次更新300条，都是先检验是否存在，存在则修改，否在 新增
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public bool AddOrUpdateToSave(List<T> ts, Expression<Func<T, bool>> whereLambda)
        {
            #region 转换成字典
            Dictionary<int, List<T>> dic = new Dictionary<int, List<T>>();
            for (int i = 0; i < ts.Count(); i++)
            {
                int key = i / 300;
                if (dic.ContainsKey(key))
                {
                    dic[key].Add(ts[i]);
                }else
                {
                    dic.Add(key, new List<T>() { ts[i] });
                }  
            }
            #endregion
            bool b = false;
            #region 循环更新字典
            foreach (var k in dic.Keys)
            {
                for (int j = 0; j < dic[k].Count; j++)
                {
                    var t = ts[j];
                    if (Exists(whereLambda)) // 存在,修改
                    {
                        Update(t);
                    }
                    else // 不存在，新增
                    {
                        Add(t);
                    }
                }
                b = SaveChanges(); // 更新到数据库
            }
            #endregion
            return b;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 获取存在
        /// </summary>
        /// <param name="whereLambda">(p=>p.id==1)</param>
        /// <returns>T</returns>
        public bool Exists(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda).First() == null ? false : true;
        }
        
        /// <summary>
        /// 获取第一个
        /// </summary>
        /// <param name="whereLambda">(p=>p.id==1)</param>
        /// <returns>T</returns>
        public T GetFirst(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda).FirstOrDefault();
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLambda">(p=>p.id==1)</param>
        /// <returns>[{},{},{}]</returns>
        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="pageSize">每页数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="OrderByLambda">()</param>
        /// <param name="WhereLambda">(p=>p.id==1)</param>
        /// <returns></returns>
        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            //是否升序
            if (isAsc)
            {
                return dbContext.Set<T>().Where(WhereLambda).OrderBy(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return dbContext.Set<T>().Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

        #endregion

    }
}
