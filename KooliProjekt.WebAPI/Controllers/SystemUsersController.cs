using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using KooliProjekt.Application.Features.SystemUsers;

namespace KooliProjekt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SystemUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetSystemUserListQuery query)
        {
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var query = new GetSystemUserQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}