using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;

namespace University.Contexts
{
    public interface IContext
    {
        IMongoCollection<Student> Students { get; }
        IMongoCollection<Class> Classes { get; }
        IMongoCollection<Semester> Semesters { get; }
        IMongoCollection<Instructor> Instructors { get; }
    }
}
