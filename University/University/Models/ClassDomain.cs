using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class ClassDomain
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<SemesterDomain> Semester { get; set; } // reference to Semester Collection
        public List<InstructorDomain> Instructor { get; set; } // reference to Instructor Collection
    }
}
