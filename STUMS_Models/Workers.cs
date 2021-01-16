using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace STUMS_Models
{
    public class Workers
    {
        [Key]
        public string No { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime InJobTime { get; set; }
        public int State { get; set; }
        public string NowAddress { get; set; }
        public string IDCardNo { get; set; }
    }
}
