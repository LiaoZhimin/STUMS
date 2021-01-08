﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUMS_Models
{
    public class School
    {
        [Key]
        public string No { get; set; }
        public string SchoolName { get; set; }
        public string Addr { get; set; }
        public double Longitude { get; set; }
        public double latitude { get; set; }
    }
}
