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
    [Route("api/Semester")]
    [ApiController]
    public class SemesterController : Controller
    {
        private readonly ISemesterRepository _semesterRepository;

        public SemesterController(ISemesterRepository semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }

        // GET: api/Semester
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _semesterRepository.GetAllSemesters());
        }

        // GET: api/Semester/id
        [HttpGet("{id}", Name = "GetSemester")]
        public async Task<IActionResult> Get(int id)
        {
            var semester = await _semesterRepository.GetSemester(id);
            if (semester == null)
                return new NotFoundResult();
            return new ObjectResult(semester);
        }

        // POST: api/Semester
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Semester semester)
        {
            DateTime createDate = DateTime.Now;
            semester.CreatedDate = createDate;
            await _semesterRepository.Create(semester);
            return new OkObjectResult(semester);
        }

        // PUT: api/Semester/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Semester semester)
        {
            var semesterFromDb = await _semesterRepository.GetSemester(id);
            if (semesterFromDb == null)
                return new NotFoundResult();
            semesterFromDb.SemesterId = semester.SemesterId;
            semesterFromDb.SemesterName = semester.SemesterName;
            DateTime updateDate = DateTime.Now;
            semesterFromDb.UpdatedDate = updateDate;
            await _semesterRepository.Update(semesterFromDb);
            return new OkObjectResult(semesterFromDb);
        }

        // DELETE: api/Semester/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var semesterFromDb = await _semesterRepository.GetSemester(id);
            if (semesterFromDb == null)
                return new NotFoundResult();
            await _semesterRepository.Delete(id);
            return new OkResult();
        }
    }
}
