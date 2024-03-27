using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week17.Service;

namespace Week17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet, Route("GetAllStudent")]
        public async Task<IActionResult> GetAllStudent()
        {
            var results = await _studentService.GetAllStudent();
            return Ok(results);
        }

        [HttpGet, Route("GetStudentById")]
        public async Task<IActionResult> GetStudentById(string id)
        {
            var result = await _studentService.GetStudentById(id);
            return Ok(result);
        }

        [HttpPost, Route("AddStudent")]
        public async Task<IActionResult> AddStudent(Student student)
        {
            var addStudent = await _studentService.AddStudent(student);
            return Ok(addStudent);
        }

        [HttpPut, Route("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            var result = await _studentService.UpdateStudent(student);
            return Ok(result);
        }

        [HttpDelete, Route("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            await _studentService.DeleteStudent(id);
            return Ok();
        }
    }
}
