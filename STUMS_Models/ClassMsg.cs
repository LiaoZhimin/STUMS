using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace STUMS_Models
{
    public class ClassMsg
    {
        [Key]
        public string CNO { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }        
        public DateTime CreateTime { get; set; }
        public DateTime CloseTime { get; set; }        
    }
}
