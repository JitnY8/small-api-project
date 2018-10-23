using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class Student : Person
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int StudentId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<int> ClassAttend { get; set; } // reference to Class Collection
    }
}
