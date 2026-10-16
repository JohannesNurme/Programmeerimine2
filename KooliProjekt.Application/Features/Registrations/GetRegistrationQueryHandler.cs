using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Registrations
{
    public class GetRegistrationQueryHandler : IRequestHandler<GetRegistrationQuery, Registration>
    {
        private readonly ApplicationDbContext _context;

        public GetRegistrationQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Registration> Handle(GetRegistrationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Registrations
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
        }
    }
}