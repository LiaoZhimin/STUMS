using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace STUMS_DAL
{
    public class MyDBContextFactory
    {
        /// <summary>
        /// 创建EF上下文对象,已存在就直接取,不存在就创建,保证线程内是唯一。
        /// </summary>
        public static MyDBContext Create()
        {
            MyDBContext dbContext = CallContext.GetData("MyDBContext") as MyDBContext;
            if (dbContext == null)
            {
                dbContext = new MyDBContext();               
                dbContext.Database.CreateIfNotExists();// 如果数据库不存在，则调用EF内置的API创建数据库
                CallContext.SetData("DbContext", dbContext);               
            }
            return dbContext;

        }
    }
}
