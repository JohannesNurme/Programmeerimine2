using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Invoices
{
    public class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, Invoice>
    {
        private readonly ApplicationDbContext _context;

        public GetInvoiceQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            return await _context.Invoices
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
        }
    }
}