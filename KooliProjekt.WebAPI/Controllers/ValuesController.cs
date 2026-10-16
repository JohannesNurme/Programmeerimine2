using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // List meetod (kõigi kirjete pärimiseks)
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            var query = new GetCustomerListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // Get meetod ID järgi
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            // 8. Kontrollige, et Id poleks 0 või negatiivne. Kui on, tagastage NotFound()
            if (id <= 0)
            {
                return NotFound();
            }

            var query = new GetCustomerQuery { Id = id };
            var result = await _mediator.Send(query);

            // 9. Kui mediaator tagastas nulli, tagastage NotFound()
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}