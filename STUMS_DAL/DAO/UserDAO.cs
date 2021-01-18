using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STUMS_Models;

namespace STUMS_DAL.DAO
{
    public class UserDAO:BaseDAO<User>
    {

        public User Login(string usercode, string pwd)
        {
            //var rlt = this.dbContext.Users.Find(new { UserCode = usercode, Pwd = pwd });
            var rlt = GetModels(u => u.UserCode == usercode && u.Pwd == pwd).ToList();
            return rlt.Count>0?rlt[0]: null;
        }
       
    }
}

