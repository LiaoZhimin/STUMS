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
            var rlt = this.dbContext.Users.Find(new { UserCode = usercode, Pwd = pwd });
            return rlt;
        }
    }
}
