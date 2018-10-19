using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;
using University.Contexts;
using MongoDB.Driver;

namespace University.Repositories
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly IContext _context;

        public SemesterRepository(IContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Semester>> GetAllSemesters()
        {
            return await _context
                            .Semesters
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<Semester> GetSemester(int id)
        {
            FilterDefinition<Semester> filter = Builders<Semester>.Filter.Eq(m => m.SemesterId, id);
            return _context
                    .Semesters
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(Semester semester)
        {
            await _context.Semesters.InsertOneAsync(semester);
        }

        public async Task<bool> Update(Semester semester)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Semesters
                        .ReplaceOneAsync(
                            filter: g => g.SemesterId == semester.SemesterId,
                            replacement: semester);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(int id)
        {
            FilterDefinition<Semester> filter = Builders<Semester>.Filter.Eq(m => m.SemesterId, id);
            DeleteResult deleteResult = await _context
                                                .Semesters
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
