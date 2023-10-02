using Application.Bars.Commands.CreateBar;
using Application.Bars.Commands.DeleteBar;
using Application.Bars.Commands.UpdateBar;
using Application.Bars.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/bars")]
    public class BarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBar([FromBody] CreateBarCommand command)
        {
            // Appel du gestionnaire de commande pour créer un bar
            await _mediator.Send(command);
            return Ok("Bar created successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBars()
        {
            var query = new GetBarsQuery();
            var bars = await _mediator.Send(query);

            return Ok(bars);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBar(int id, [FromBody] UpdateBarCommand command)
        {
            if (id != command.Id) return BadRequest();

            await _mediator.Send(command);
            return Ok("Bar updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var command = new DeleteBarCommand(id) ;
            await _mediator.Send(command);
            return Ok("Bar deleted successfully");
        }
    }
}
