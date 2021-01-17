using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace STUMS_Models
{
    public class User
    {
        [Key]
        public string UserCode { get; set; }
        public string Pwd { get; set; }
        public string Role { get; set; }
        public string Limits { get; set; }
        public int State { get; set; }
        public string Editor { get; set; }
        public DateTime EditTime { get; set; }
    }
}
