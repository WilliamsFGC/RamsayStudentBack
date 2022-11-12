using Microsoft.AspNetCore.Mvc;
using Student.Business.interfaces;
using Student.Entities.Dto;

namespace Student.API.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost("[action]")]
        public IActionResult Save(StudentDto student)
        {
            var result = studentService.Save(student);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("[action]")]
        public IActionResult Update(StudentDto student)
        {
            var result = studentService.Update(student);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = studentService.GetAll();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("[action]")]
        public IActionResult Get([FromQuery]StudentDto student)
        {
            var result = studentService.Get(student);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            var result = studentService.Delete(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
