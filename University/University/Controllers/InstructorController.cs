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
    [Route("api/Instructor")]
    [ApiController]
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorController(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        // GET: api/Instructor
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _instructorRepository.GetAllInstructors());
        }

        // GET: api/Instructor/id
        [HttpGet("{id}", Name = "GetInstructor")]
        public async Task<IActionResult> Get(int id)
        {
            var instructor = await _instructorRepository.GetInstructor(id);
            if (instructor == null)
                return new NotFoundResult();
            return new ObjectResult(instructor);
        }

        // POST: api/Instructor
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Instructor instructor)
        {
            DateTime createDate = DateTime.Now;
            instructor.CreatedDate = createDate;
            await _instructorRepository.Create(instructor);
            return new OkObjectResult(instructor);
        }

        // PUT: api/Instructor/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Instructor instructor)
        {
            var instructorFromDb = await _instructorRepository.GetInstructor(id);
            if (instructorFromDb == null)
                return new NotFoundResult();
            instructorFromDb.InstructorId = instructor.InstructorId;
            instructorFromDb.LastName = instructor.LastName;
            instructorFromDb.FirstName = instructor.FirstName;
            DateTime updateDate = DateTime.Now;
            instructorFromDb.UpdatedDate = updateDate;
            await _instructorRepository.Update(instructorFromDb);
            return new OkObjectResult(instructorFromDb);
        }

        // DELETE: api/Instructor/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var instructorFromDb = await _instructorRepository.GetInstructor(id);
            if (instructorFromDb == null)
                return new NotFoundResult();
            await _instructorRepository.Delete(id);
            return new OkResult();
        }
    }
}
