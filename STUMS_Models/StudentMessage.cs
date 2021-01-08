using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STUMS_Models
{
    public class StudentMessage
    {
        [ForeignKey("No")]
        public Students Student { get; set; }
        public string SchoolNo { get; set; }
        public string MajorNo { get; set; }
        public string ClassNo { get; set; }
        public string MainTreacherNo { get; set; }
        public string DormNo { get; set; }
    }
}
