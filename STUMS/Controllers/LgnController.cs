using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;


namespace STUMS.Controllers
{
    using System.Web.Http;

    public class LgnController : ApiController
    {
        /// <summary>
        /// 登录，账号UUUU,密码PPPP校验
        /// </summary>
        /// <param name="mm">UUUU账号，PPPP密码</param>
        /// <returns></returns>
        public string Post([FromBody]STUMS_Models.Lgn_M mm)
        {
            mm.PPPP = STUMS_Helper.SS.PwdEncrypt(mm.PPPP);
            var tk = SS.SetUserToken(mm);
            if (string.IsNullOrEmpty (tk)) { return "NG"; }
            return "OK,"+tk;
        }

    }
}
