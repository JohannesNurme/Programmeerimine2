using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Events
{
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, List<Event>>
    {
        private readonly ApplicationDbContext _context;

        public GetEventListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Events
                .ToListAsync(cancellationToken);
        }
    }
}