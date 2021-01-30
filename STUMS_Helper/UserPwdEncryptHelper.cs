
namespace STUMS_Helper
{
    using System;
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

        public string TokenEncrypt(string msg,int expireMinu = 480)
        {
            if (string.IsNullOrEmpty(msg)) { return ""; }
            string m1 = msg + "|" + DateTime.Now.AddMinutes(expireMinu).ToString("yyyy-MM-dd HH:mm:ss");
            return UserEncrypt(m1);
        }
        public string TokenDecrypt(string tk)
        {
            if (string.IsNullOrEmpty(tk)) { return ""; }
            string ms = UserDecrypt(tk);
            string[] ss = ms.Split('|');
            if (DateTime.Now > Convert.ToDateTime(ss[ss.Length - 1]))
            {
                return "";
            }
            return ms;
        }
    }

}
