﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class ClassDomain
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public List<Semester> Semester { get; set; } // reference to Semester Collection
        public List<Instructor> Instructor { get; set; } // reference to Instructor Collection
    }
}
