using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace STUMS_Models
{
    public class Teachers
    {
        [Key]
        public string TCode { get; set; }
        public string TName { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public string Addr { get; set; }
        public string Email { get; set; }
        public string QQ { get; set; }
        public string Phone { get; set; }

        public string IDCardNo { get; set; }
        [ForeignKey("IDCardNo")]
        public IDCards IDCard { get; set; }

    }
}
