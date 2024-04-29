using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickMarkAttendance.Application.DTOs.Attendance.request;
using QuickMarkAttendance.Application.SQRS.Attendance.AddAttendance;
using QuickMarkAttendance.Application.SQRS.AttendanceFeature.GetAllAttendedStudentsForCourse;
using QuickMarkAttendance.Application.SQRS.StudentFeature.GetStudent;
using QuickMarkAttendance.Domain.Entity.StudentDomain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickMarkAttendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IMediator mediator;

        public AttendanceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/<AttendanceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AttendanceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("GetAttendedStudents/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            List<Student> students = new List<Student>();
            var result = await mediator.Send(new GetAttendedStudentsForCourseQuery(id));

            foreach (var item in result.Value)
            {
                var student = await mediator.Send(new GetStudentQuery(item.StudentId.value));

                students.Add(student);
            }

            return Ok(Result.Success(students));
        }

        // POST api/<AttendanceController>
        [HttpPost("AddAttendance")]
        public async Task<IActionResult> Post([FromBody] AddAttendanceRequest request)
        {
            var result = await mediator.Send(new CreateAttendanceCommand(request.courseId,request.studentId));
            return Ok(result);
        }

        // PUT api/<AttendanceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AttendanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
