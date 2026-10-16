using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.EventFiles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventFilesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public EventFilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventFile>>> Get()
        {
            var query = new GetEventFileListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventFile>> Get(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var query = new GetEventFileQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}