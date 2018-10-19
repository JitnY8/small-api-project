using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;

namespace University.Repositories
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAllClasses();
        Task<Class> GetClass(int id);
        Task<Instructor> GetClassInstructor(int id);
        Task<Semester> GetClassSemester(int id);
        Task Create(Class _class);
        Task<bool> Update(Class _class);
        Task<bool> Delete(int id);
    }
}
