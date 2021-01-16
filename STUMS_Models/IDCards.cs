using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace STUMS_Models
{
    public class IDCards
    {
        [Key]
        public string No { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Province { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string Folk { get; set; }
        public string BirthDay { get; set; }
        /// <summary>
        /// 发证单位
        /// </summary>
        public string Org { get; set; }
    }
}
