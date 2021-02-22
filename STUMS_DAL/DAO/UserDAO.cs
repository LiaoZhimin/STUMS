

namespace STUMS_DAL.DAO
{
    using System.Linq;
    using STUMS_Models;
    public class UserDAO:BaseDAO<User>
    {
        public User Login(string usercode, string pwd)
        {
            // var rlt = this.dbContext.Users.Find(new { UserCode = usercode, Pwd = pwd });
            var rlt = GetModels(u => u.UserCode == usercode && u.Pwd == pwd).ToList();
            return rlt.Count > 0 ? rlt[0] : null;
        }
    }
}