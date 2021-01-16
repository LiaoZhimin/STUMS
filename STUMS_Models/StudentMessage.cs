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

        [Key]
        public string StudentNo { get; set; }
        [ForeignKey("StudentNo")]
        public virtual Students Student { get; set; }

        public string SchoolNo { get; set; }
        [ForeignKey("SchoolNo")]
        public virtual School School { get; set; }

        public string MajorNo { get; set; }
        [ForeignKey("MajorNo")]
        public virtual Major Major { get; set; }

        public string ClassNo { get; set; }
        [ForeignKey("ClassNo")]
        public virtual ClassMsg ClassMsg { get; set; }

        public string TreacherNo { get; set; }
        [ForeignKey("TreacherNo")]
        public virtual Teachers Teacher { get; set; }

        public string DormNo { get; set; }
        [ForeignKey("DormNo")]
        public virtual Dormitory Dormitory { get; set; }
    }
}
