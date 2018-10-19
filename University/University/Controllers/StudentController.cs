using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.Models;
using University.Repositories;

namespace University.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var student = await _studentRepository.GetAllStudents();
            return new ObjectResult(student);
        }

        // GET: api/Student/id
        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<IActionResult> Get(int id)
        {
            Student student = new Student();
            StudentDomain studentDomain = new StudentDomain();
            ClassDomain _class = new ClassDomain();

            var studentFromDB = await _studentRepository.GetStudent(id);

            if (studentFromDB == null)
                return new NotFoundResult();
            studentDomain.StudentId = studentFromDB.StudentId;
            studentDomain.FirstName = studentFromDB.FirstName;
            studentDomain.LastName = studentFromDB.LastName;
            studentDomain.DateOfBirth = studentFromDB.DateOfBirth;
            student.ClassAttend = studentFromDB.ClassAttend;

            var attends = new List<ClassDomain>();

            foreach (var attend in student.ClassAttend)
            {
                var classFromDB = await _studentRepository.GetStudentClass(attend);
                if (classFromDB != null)
                {
                    attends.Add(new ClassDomain
                    {
                        ClassId = classFromDB.ClassId,
                        ClassName = classFromDB.ClassName
                    });
                }
            }
            
            studentDomain.ClassAttend =attends;

            return new ObjectResult(studentDomain);
        }

        // POST: api/Student
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Student student)
        {
            await _studentRepository.Create(student);
            return new OkObjectResult(student);
        }

        // PUT: api/Student/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Student student)
        {
            var studentFromDb = await _studentRepository.GetStudent(id);
            if (studentFromDb == null)
                return new NotFoundResult();
            studentFromDb.StudentId = student.StudentId;
            studentFromDb.FirstName = student.FirstName;
            studentFromDb.LastName = student.LastName;
            studentFromDb.DateOfBirth = student.DateOfBirth;
            studentFromDb.ClassAttend = student.ClassAttend;
            await _studentRepository.Update(studentFromDb);
            return new OkObjectResult(studentFromDb);
        }

        // DELETE: api/Student/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var studentFromDb = await _studentRepository.GetStudent(id);
            if (studentFromDb == null)
                return new NotFoundResult();
            await _studentRepository.Delete(id);
            return new OkResult();
        }
    }
}
