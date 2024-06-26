﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Galkin.Model
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public DateTime DateExecute { get; set; }
        public string Comment { get; set; }
        public bool Done { get; set; }
    }
}
