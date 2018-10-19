using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace University.Models
{
    public class Instructor
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int InstructorId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
