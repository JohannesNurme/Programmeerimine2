using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Events
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, Event>
    {
        private readonly ApplicationDbContext _context;

        public GetEventQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Event> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            return await _context.Events
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
        }
    }
}