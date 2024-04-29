using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickMarkAttendance.Application.SQRS.DoctorFeature.GetAllDoctors;
using QuickMarkAttendance.Application.SQRS.DoctorFeature.GetSingleDoctor;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickMarkAttendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<DoctorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllDoctorsQuery()) ;

            return Ok(result);
        }

        // GET api/<DoctorController>/5
        [HttpGet("GetSingleDoctor/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetSingleDoctorQuery(id));

            return Ok(result);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
