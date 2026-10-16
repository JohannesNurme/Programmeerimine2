using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Payments
{
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, Payment>
    {
        private readonly ApplicationDbContext _context;

        public GetPaymentQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            return await _context.Payments
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
        }
    }
}