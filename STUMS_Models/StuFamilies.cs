using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STUMS_Models
{
    public class StuFamilies
    {
        [Key]
        [Column(Order =1)]
        public string StuNo { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Name { get; set; }
        public string Rel { get; set; }
        public string Nation { get; set; }
        public string Addr { get; set; }
        public string Phone { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
