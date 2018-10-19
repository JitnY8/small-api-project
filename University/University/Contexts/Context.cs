using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;

namespace University.Contexts
{
    public class Context : IContext
    {
        private readonly IMongoDatabase _db;

        public Context(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Student> Students => _db.GetCollection<Student>("Students");
        public IMongoCollection<Class> Classes => _db.GetCollection<Class>("Classes");
        public IMongoCollection<Semester> Semesters => _db.GetCollection<Semester>("Semesters");
        public IMongoCollection<Instructor> Instructors => _db.GetCollection<Instructor>("Instructors");
    }
}
