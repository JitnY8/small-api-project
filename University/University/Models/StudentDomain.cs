using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class StudentDomain : Person
    {
        public int StudentId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<ClassDomain> ClassAttend { get; set; }
    }
}
