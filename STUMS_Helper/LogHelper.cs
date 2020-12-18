using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUMS_Helper
{
    internal class LogHelper
    {
        public string Msg { get; set; }
        public bool WriteLog(string msg, string filepath = "", string timeFormat = "yyyyMM")
        {
            try
            {
                if (string.IsNullOrEmpty(filepath))
                {
                    filepath = System.AppDomain.CurrentDomain.BaseDirectory + "log/" + DateTime.Now.ToString(timeFormat) + ".log";
                }
                System.IO.FileInfo fi = new System.IO.FileInfo(filepath);
                if (!fi.Directory.Exists)
                {
                    fi.Directory.Create();
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(filepath, true);
                string line = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " >> " + msg;
                sw.WriteLine(line);
                sw.Close();
                sw.Dispose();
                Msg = "OK";
                return true;
            }
            catch (Exception err)
            {
                string str = err.StackTrace;
                Msg = "Error : "
                    + str.Substring(str.LastIndexOf("\\") + 1, str.Length - str.LastIndexOf("\\") - 1)
                    + "--" + err.Message;
                return false;
            }
        }
        public void WriteLogAsyn(string msg)
        {
            System.Threading.ThreadPool.QueueUserWorkItem((obj) => {
                WriteLog(obj.ToString());
            }, msg);
        }
        public void WriteLogAsynDate(Log log)
        {
            System.Threading.ThreadPool.QueueUserWorkItem((obj) => {
                try
                {
                    Log log2 = (Log)obj;
                    string ss = "";
                    foreach (string s in log2.Args)
                    {
                        ss += s + "|";
                    }
                    ss += log2.Msg;
                    WriteLog(ss, "", "yyyyMMdd");
                }
                catch { }
            }, log);
        }
    }
}
