using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Registrations
{
    public class GetRegistrationListQueryHandler : IRequestHandler<GetRegistrationListQuery, List<Registration>>
    {
        private readonly ApplicationDbContext _context;

        public GetRegistrationListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Registration>> Handle(GetRegistrationListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Registrations
                .ToListAsync(cancellationToken);
        }
    }
}