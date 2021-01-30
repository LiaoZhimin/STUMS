
namespace STUMS_Helper
{
    using System;
    public class SS
    {
        #region Log

        /// <summary>
        /// 写入log
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="filepath"></param>
        /// <param name="timeFormat"></param>
        /// <returns></returns>
        public static string WriteLog(string msg, string filepath = "", string timeFormat = "yyyyMM")
        {
            var lh = new LogHelper();
            lh.WriteLog(msg, filepath, timeFormat);
            return lh.Msg;
        }
        /// <summary>
        /// 异步写入 log
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string WriteLogAsyn(string msg)
        {
            var lh = new LogHelper();
            lh.WriteLogAsyn(msg);
            return lh.Msg;
        }
        /// <summary>
        /// 异步写入 log
        /// </summary>
        /// <param name="msg"></param>
    	/// <param name="beforeArgs">用|隔开的各段字符串</param>
        /// <returns></returns>
        public static string WriteLogAsynDate(string msg, params string[] beforeArgs)
        {
            var lh = new LogHelper();
            lh.WriteLogAsynDate(new Log(msg, beforeArgs));
            return lh.Msg;
        }

        #endregion

        #region MD5
        public static string MD5Encrypt(string value, string key)
        {
            var mm = new MD5Helper();
            return mm.MD5Encrypt(value, key);
        }
        public static string MD5Decrypt(string value, string key)
        {
            var mm = new MD5Helper();
            return mm.MD5Decrypt(value, key);
        }
        #endregion

        #region UserPwd Encrypt
        public static string UserEncrypt(string usercode)
        {
            return new UserPwdEncryptHelper().UserEncrypt(usercode);
        }
        public static string UserDecrypt(string userCryStr)
        {
            return new UserPwdEncryptHelper().UserDecrypt(userCryStr);
        }
        public static string PwdEncrypt(string pwd)
        {
            return new UserPwdEncryptHelper().PwdEncrypt(pwd);
        }
        public static string PwdDecrypt(string pwdCryStr)
        {
            return new UserPwdEncryptHelper().PwdDecrypt(pwdCryStr);
        }
        #endregion

        #region 代码异常信息处理
        /// <summary>
        /// 处理异常报错信息，取得自己需要的异常信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string myGetExceptionMsg(Exception ex)
        {
            string str = ex.StackTrace;
            string msg = "Error : "
                + str.Substring(str.LastIndexOf("\\") + 1, str.Length - str.LastIndexOf("\\") - 1)
                + "--" + ex.Message;
            return msg;
        }
        #endregion

        #region Token
        public static string TokenEncrypt(string msg, int expireMinu = 480)
        {           
            return new UserPwdEncryptHelper().TokenEncrypt(msg,expireMinu) ;
        }
        public static string TokenDecrypt(string tk)
        {
            return new UserPwdEncryptHelper().TokenDecrypt(tk);
        }
        #endregion

    }

}
