using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;

namespace University.Repositories
{
    public interface ISemesterRepository
    {
        Task<IEnumerable<Semester>> GetAllSemesters();
        Task<Semester> GetSemester(int id);
        Task Create(Semester semester);
        Task<bool> Update(Semester semester);
        Task<bool> Delete(int id);
    }
}
