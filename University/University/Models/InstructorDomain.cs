using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class InstructorDomain : Person
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int InstructorId { get; set; }
    }
}
