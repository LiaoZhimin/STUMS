using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUMS_Helper
{
    internal class UserPwdEncryptHelper
    {
        public string UserEncrypt(string usercode)
        {
            string rlt = SS.MD5Encrypt(usercode, "33668822");
            return rlt;
        }
        public string UserDecrypt(string userCryStr)
        {
            string rlt = SS.MD5Decrypt(userCryStr, "33668822");
            return rlt;
        }
        public string PwdEncrypt(string pwd)
        {
            string rlt = SS.MD5Encrypt(pwd, "11552299");
            return rlt;
        }
        public string PwdDecrypt(string pwdCryStr)
        {
            string rlt = SS.MD5Decrypt(pwdCryStr, "11552299");
            return rlt;
        }
    }
}
