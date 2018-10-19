using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;

namespace University.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudent(int id);
        Task<Class> GetStudentClass(int id);
        Task Create(Student student);
        Task<bool> Update(Student student);
        Task<bool> Delete(int id);
    }
}
