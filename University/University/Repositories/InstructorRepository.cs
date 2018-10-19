using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;
using University.Contexts;
using MongoDB.Driver;

namespace University.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly IContext _context;

        public InstructorRepository(IContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructors()
        {
            return await _context
                            .Instructors
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<Instructor> GetInstructor(int id)
        {
            FilterDefinition<Instructor> filter = Builders<Instructor>.Filter.Eq(m => m.InstructorId, id);
            return _context
                    .Instructors
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(Instructor instructor)
        {
            await _context.Instructors.InsertOneAsync(instructor);
        }

        public async Task<bool> Update(Instructor instructor)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Instructors
                        .ReplaceOneAsync(
                            filter: g => g.InstructorId == instructor.InstructorId,
                            replacement: instructor);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(int id)
        {
            FilterDefinition<Instructor> filter = Builders<Instructor>.Filter.Eq(m => m.InstructorId, id);
            DeleteResult deleteResult = await _context
                                                .Instructors
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
