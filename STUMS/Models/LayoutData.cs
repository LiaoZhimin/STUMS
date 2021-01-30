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
        /// <returns></returns>
        public static LayoutData getUserMsgFromToken(HttpContextBase hcb)
        {
            string s = SS.GetTKValue(hcb);
            if (string.IsNullOrEmpty(s))
            {
                return new LayoutData();
            }
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

    }
}