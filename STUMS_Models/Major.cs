﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace STUMS_Models
{
    public class Major
    {
        [Key]
        public string No { get; set; }
        public string Name { get; set; }
        
    }
}
