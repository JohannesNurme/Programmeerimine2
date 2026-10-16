using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Payments
{
    public class GetPaymentListQueryHandler : IRequestHandler<GetPaymentListQuery, List<Payment>>
    {
        private readonly ApplicationDbContext _context;

        public GetPaymentListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> Handle(GetPaymentListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Payments
                .ToListAsync(cancellationToken);
        }
    }
}