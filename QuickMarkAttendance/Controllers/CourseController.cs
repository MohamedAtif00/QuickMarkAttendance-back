using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickMarkAttendance.Application.DTOs.Course.Request;
using QuickMarkAttendance.Application.SQRS.CourseFeature.CreateCourse;
using QuickMarkAttendance.Application.SQRS.CourseFeature.GetAllCourses;
using QuickMarkAttendance.Application.SQRS.CourseFeature.GetCoursesForDoctor;
using QuickMarkAttendance.Application.SQRS.CourseFeature.GetSingleCourse;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickMarkAttendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GatAllCoursesQuery());

            return Ok(result);
        }

        // GET api/<CoursesController>/5
        [HttpGet("GetCourse/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetSingleCourseQuery(id));

            return Ok(result);
        }

        [HttpGet("GetCoursesForDoctor/{id}")]
        public async Task<IActionResult> GetCoursesForDoctor(Guid id)
        {
            var result = await _mediator.Send(new GetCoursesForDoctorQuery(id));

            return Ok(result);
        }
        // POST api/<CoursesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCourseRequest request)
        {
            var result = await _mediator.Send(new CreateCourseCommand(request.Name,request.DoctorId,request.description,request.link));

            return Ok(result);
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
