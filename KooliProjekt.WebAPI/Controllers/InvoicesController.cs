using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.Invoices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // List meetod (kõigi arvete pärimiseks)
        [HttpGet]
        public async Task<ActionResult<List<Invoice>>> Get()
        {
            var query = new GetInvoiceListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // Get meetod ID järgi koos kontrollidega
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> Get(int id)
        {
            // Kontroll, et Id poleks negatiivne või 0
            if (id <= 0)
            {
                return NotFound();
            }

            var query = new GetInvoiceQuery { Id = id };
            var result = await _mediator.Send(query);

            // Kontroll, kas kirje leiti
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}