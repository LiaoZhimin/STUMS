using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUMS_Helper
{
    public class Log
    {
        public Log(string msg, params string[] args)
        {
            this.Msg = msg;
            this.Args = args;
        }
        public string Msg { get; set; }
        public string[] Args { get; set; }
    }
}
