using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Customers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer>
    {
        private readonly ApplicationDbContext _context;

        public GetCustomerQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
        }
    }
}