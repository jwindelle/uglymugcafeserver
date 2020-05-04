﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UglyMugCafeServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Orders { get; set; }
        public string Status { get; set; }
        public DateTime SignalDate { get; set; }
    }
}
