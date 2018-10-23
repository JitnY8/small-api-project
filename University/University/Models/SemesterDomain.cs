using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class SemesterDomain
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
    }
}
