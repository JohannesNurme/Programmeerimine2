using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Invoices
{
    public class GetInvoiceListQueryHandler : IRequestHandler<GetInvoiceListQuery, List<Invoice>>
    {
        private readonly ApplicationDbContext _context;

        public GetInvoiceListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Invoice>> Handle(GetInvoiceListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Invoices
                .ToListAsync(cancellationToken);
        }
    }
}