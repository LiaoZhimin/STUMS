using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STUMS.Models
{
    public class MsgBoxData
    {
        public MsgBoxData():this(boxType.success,"",5)
        {}
        public MsgBoxData(boxType boxType1, string msg, int clearSecond)
        {
            this.BoxType = boxType1;
            this.Msg = msg;
            this.ClearSecond = clearSecond;
        }
        public boxType BoxType { get; set; }
        public string Msg { get; set; }
        public int ClearSecond { get; set; }

        public string GetClass()
        {
            switch (this.BoxType)
            {
                case boxType.success:
                    return "alert-success";
                case boxType.danger:
                    return "alert-danger";
                case boxType.info:
                    return "alert-info";
                case boxType.warning:
                    return "alert-warning";                   
            }
            return "";
        }
    }
    public enum boxType
    {
        success, info, warning, danger
    }
}