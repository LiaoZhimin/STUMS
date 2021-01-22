using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace STUMS.Controllers
{
    public class LgnController : ApiController
    {
        /// <summary>
        /// 登录，账号UUUU,密码PPPP校验
        /// </summary>
        /// <param name="mm">UUUU账号，PPPP密码</param>
        /// <returns></returns>
        public string Post([FromBody]STUMS_Models.Lgn_M mm)
        {
            return "OK";
        }
    }
}
