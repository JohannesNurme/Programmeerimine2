using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.SystemUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUsersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public SystemUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<SystemUser>>> Get()
        {
            var query = new GetSystemUserListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SystemUser>> Get(int id)
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