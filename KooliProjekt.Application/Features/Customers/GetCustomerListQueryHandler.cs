using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Customers
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<Customer>>
    {
        private readonly ApplicationDbContext _context;

        public GetCustomerListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .ToListAsync(cancellationToken);
        }
    }
}