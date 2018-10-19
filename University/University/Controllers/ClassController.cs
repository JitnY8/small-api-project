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
    [Route("api/Class")]
    [ApiController]
    public class ClassController : Controller
    {
        private readonly IClassRepository _classRepository;

        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        // GET: api/Class
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _classRepository.GetAllClasses());
        }

        // GET: api/Class/id
        [HttpGet("{id}", Name = "GetClass")]
        public async Task<IActionResult> Get(int id)
        {
            var _class = await _classRepository.GetClass(id);
            if (_class == null)
                return new NotFoundResult();
            return new ObjectResult(_class);
        }

        // POST: api/Class
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Class _class)
        {
            await _classRepository.Create(_class);
            return new OkObjectResult(_class);
        }

        // PUT: api/Class/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Class _class)
        {
            var classFromDb = await _classRepository.GetClass(id);
            if (classFromDb == null)
                return new NotFoundResult();
            classFromDb.ClassId = _class.ClassId;
            classFromDb.ClassName = _class.ClassName;
            classFromDb.Semester = _class.Semester;
            classFromDb.Instructor = _class.Instructor;
            await _classRepository.Update(classFromDb);
            return new OkObjectResult(classFromDb);
        }

        // DELETE: api/Class/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var classFromDb = await _classRepository.GetClass(id);
            if (classFromDb == null)
                return new NotFoundResult();
            await _classRepository.Delete(id);
            return new OkResult();
        }
    }
}
