using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;
using University.Contexts;
using MongoDB.Driver;

namespace University.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IContext _context;

        public StudentRepository(IContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {            
            return await _context
                            .Students
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<Student> GetStudent(int id)
        {
            FilterDefinition<Student> filter = Builders<Student>.Filter.Eq(m => m.StudentId, id);
            return _context
                    .Students
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public Task<Class> GetStudentClass(int id)
        {
            FilterDefinition<Class> filter = Builders<Class>.Filter.Eq(m => m.ClassId, id);
            return _context
                    .Classes
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(Student student)
        {
            await _context.Students.InsertOneAsync(student);
        }

        public async Task<bool> Update(Student student)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Students
                        .ReplaceOneAsync(
                            filter: g => g.StudentId == student.StudentId,
                            replacement: student);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(int id)
        {
            FilterDefinition<Student> filter = Builders<Student>.Filter.Eq(m => m.StudentId, id);
            DeleteResult deleteResult = await _context
                                                .Students
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
