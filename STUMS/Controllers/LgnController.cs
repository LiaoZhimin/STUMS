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

        public string Post([FromBody]STUMS_Models.Lgn_M mm)
        {
            return "OK";
        }
    }
}
