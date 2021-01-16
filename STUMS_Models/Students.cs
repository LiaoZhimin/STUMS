using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace STUMS_Models
{
    public class Students
    {
        [Key]
        public string No { get; set; }

        public string IDCardNo { get; set; }
        [ForeignKey("IDCardNo")]
        public IDCards IDCard { get; set; }
        public string Name { get; set; }       
        public DateTime InSchoolDate { get; set; }
        public DateTime LiveSchoolDate { get; set; }

    }
}
