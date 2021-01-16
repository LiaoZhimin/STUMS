using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace STUMS_Models
{
    public class StuPunishments
    {
        [Key] // 单列 Int ID 或者[ClassName]ID 键，自增
        public int ID { get; set; }
        public string StuNo { get; set; }
        [ForeignKey("StuNo")]
        public Students Student { get; set; }
        public string Reason { get; set; }
        public string Punishment { get; set; }
        public string Date { get; set; }
        public string Giver { get; set; }
        public string Remark { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
