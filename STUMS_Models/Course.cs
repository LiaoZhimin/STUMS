using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUMS_Models
{
    public class Course
    {
        public string No { get; set; }
        public string Name { get; set; }
        public int Point { get; set; }
        public string BookNo { get; set;}
        public int Hours { get; set; }
        public bool IsMust { get; set; }
    }
}
