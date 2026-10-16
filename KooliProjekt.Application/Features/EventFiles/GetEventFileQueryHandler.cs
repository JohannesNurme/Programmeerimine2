using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.EventFiles
{
    public class GetEventFileQueryHandler : IRequestHandler<GetEventFileQuery, EventFile>
    {
        private readonly ApplicationDbContext _context;

        public GetEventFileQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EventFile> Handle(GetEventFileQuery request, CancellationToken cancellationToken)
        {
            return await _context.EventFiles
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
        }
    }
}