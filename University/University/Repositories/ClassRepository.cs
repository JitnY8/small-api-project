using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;
using University.Contexts;
using MongoDB.Driver;

namespace University.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly IContext _context;

        public ClassRepository(IContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Class>> GetAllClasses()
        {
            return await _context
                            .Classes
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<Class> GetClass(int id)
        {
            FilterDefinition<Class> filter = Builders<Class>.Filter.Eq(m => m.ClassId, id);
            return _context
                    .Classes
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(Class _class)
        {
            await _context.Classes.InsertOneAsync(_class);
        }

        public async Task<bool> Update(Class _class)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Classes
                        .ReplaceOneAsync(
                            filter: g => g.ClassId == _class.ClassId,
                            replacement: _class);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(int id)
        {
            FilterDefinition<Class> filter = Builders<Class>.Filter.Eq(m => m.ClassId, id);
            DeleteResult deleteResult = await _context
                                                .Classes
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
