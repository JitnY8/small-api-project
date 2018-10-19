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
            return new ObjectResult(await _studentRepository.GetAllStudents());
        }

        // GET: api/Student/id
        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _studentRepository.GetStudent(id);
            if (student == null)
                return new NotFoundResult();
            return new ObjectResult(student);
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
