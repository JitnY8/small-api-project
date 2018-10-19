using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace University.Models
{
    [Serializable]
    public class Class
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public List<int> Semester { get; set; } // reference to Semester Collection
        public List<int> Instructor { get; set; } // reference to Instructor Collection
    }
}
