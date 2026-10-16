using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.SystemUsers
{
    public class GetSystemUserQueryHandler : IRequestHandler<GetSystemUserQuery, SystemUser>
    {
        private readonly ApplicationDbContext _context;

        public GetSystemUserQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SystemUser> Handle(GetSystemUserQuery request, CancellationToken cancellationToken)
        {
            return await _context.SystemUsers
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
        }
    }
}