using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.Registrations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public RegistrationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Registration>>> Get()
        {
            var query = new GetRegistrationListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> Get(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var query = new GetRegistrationQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}