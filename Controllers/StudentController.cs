

using CQRSMediatrDemo.Commands.CreateStudent;
using CQRSMediatrDemo.Commands.DeleteStudent;
using CQRSMediatrDemo.Commands.UpdateStudent;
using CQRSMediatrDemo.Requests.GetAllStudents;
using CQRSMediatrDemo.Requests.GetStudentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatrDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery(id));
            if (student is null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
        {
            if (command is null) return BadRequest();
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentCommand command)
        {
            if (command is null) return BadRequest();
            if (id != command.Id) return BadRequest("Id in URL and body must match.");
            var success = await _mediator.Send(command);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteStudentCommand(id));
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
