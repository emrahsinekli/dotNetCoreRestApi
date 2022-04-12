using dotNetCoreRestApi.Models;
using dotNetCoreRestApi.StudentData;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace dotNetCoreRestApi.Controllers
{

    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentData _studentData;
        private readonly ILogger<StudentsController> logger;
        public StudentsController(IStudentData studentData,ILogger<StudentsController> logger)
        {
            _studentData = studentData;
            this.logger = logger; ;
        }

        [HttpGet]
        [Route("api/[controller]/[Action]")]
        public IActionResult GetAllStudents()
        {
      
            return Ok(_studentData.GetAllStudents());
        }

        [HttpGet]
        [Route("api/[controller]/[Action]/{id}")]
        public IActionResult GetStudentById(Guid id)
        {
            logger.LogInformation("DENEMEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE LogInformation");
            logger.LogError("DENEMEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE LogError");
            logger.LogWarning("DENEMEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE ELogWarning");
            logger.LogDebug("DENEMEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEeeeeeeeeeeeeeeeeeeeeeeeeeeeeeEEEEEEEEEEE ELogWarning");
            
            var student = _studentData.GetStudentById(id);
            if (student != null) { return Ok(student); }
            return NotFound($"Student not found with this id {id}");
        }

        [HttpPost]
        [Route("api/[controller]/[Action]")]
        public IActionResult AddStudent(Student student)
        {
            _studentData.AddStudent(student);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + student.Id, student);
        }

        [HttpDelete]
        [Route("api/[controller]/[Action]/{id}")]
        public IActionResult DeleteStudent(Guid id)
        {
            var student = _studentData.GetStudentById(id);
            if (student != null)
            {
                _studentData.DeleteStudent(student);
                return NotFound($"Student deleted with this id {id}");
            }
            return NotFound($"Student not found with this id {id}");
        }

        [HttpPatch]
        [Route("api/[controller]/[Action]/{id}")]
        public IActionResult EditStudent(Guid id, Student student)
        {
            var existStudent = _studentData.GetStudentById(id);
            if (existStudent != null)
            {
                student.Id = existStudent.Id;
                _studentData.EditStudent(student);
            }
            return Ok(student);
        }
    }
}
