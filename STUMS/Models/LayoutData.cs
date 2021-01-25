using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STUMS.Models
{
    public class LayoutData
    {
        /// <summary>
        /// 是否已经登录
        /// </summary>
        public bool IsLogin { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户代码
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PPPP { get; set; }
        /// <summary>
        /// 邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 从cookie的tk中提取用户信息
        /// </summary>
        /// <param name="tk"></param>
        /// <returns></returns>
        public static LayoutData getUserMsgFromCookie(string tk)
        {
            string s = STUMS_Helper.SS.UserDecrypt(tk);
            string[] ss = s.Split('|');
            LayoutData ld = new LayoutData()
            {
                IsLogin = ss.Length>0&&ss[0].Length>0,
                UserCode  = ss[0],
                UserName = ss[1],
                Email = ss[2]
            };
            return ld;
        }

        /// <summary>
        /// 将LayoutData的信息 加密成token
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static string getCookieTokenFrom(LayoutData ld)
        {
            if (string.IsNullOrEmpty(ld.UserCode))
            {
                return "";
            }
            string s = ld.UserCode + "|" + ld.UserName + "" + ld.Email;
            s = STUMS_Helper.SS.UserEncrypt(s);
            return s;
        }
    }
}