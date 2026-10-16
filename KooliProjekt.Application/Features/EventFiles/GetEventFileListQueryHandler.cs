using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.EventFiles
{
    public class GetEventFileListQueryHandler : IRequestHandler<GetEventFileListQuery, List<EventFile>>
    {
        private readonly ApplicationDbContext _context;

        public GetEventFileListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EventFile>> Handle(GetEventFileListQuery request, CancellationToken cancellationToken)
        {
            return await _context.EventFiles
                .ToListAsync(cancellationToken);
        }
    }
}