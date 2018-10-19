using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace University.Models
{
    public class Semester
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int SemesterId { get; set; } 
        public string SemesterName { get; set; } 
    }
}
