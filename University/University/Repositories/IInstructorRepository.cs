using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;

namespace University.Repositories
{
     public interface IInstructorRepository
    {
        Task<IEnumerable<Instructor>> GetAllInstructors();
        Task<Instructor> GetInstructor(int id);
        Task Create(Instructor instructor);
        Task<bool> Update(Instructor instructor);
        Task<bool> Delete(int id);
    }
}
