using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUMS_Helper
{
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
    }
}
