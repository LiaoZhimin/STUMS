using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace STUMS_Models
{
    public class Dormitory
    {
        [Key]
        public string DCode { get; set; }
        public string DName { get; set; }
        public string ManagerNo { get; set; }
        public string Addr { get; set; }
        public int FloorQty { get; set; }
        public int RoomQty { get; set; }
        public int ALLMenQty { get; set; }
        public int NowLiveQty { get; set; }
    }
}
