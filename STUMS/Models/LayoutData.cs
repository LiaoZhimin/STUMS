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

    }
}