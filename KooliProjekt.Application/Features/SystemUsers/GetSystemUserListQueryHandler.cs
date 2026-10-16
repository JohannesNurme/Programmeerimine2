using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.SystemUsers
{
    public class GetSystemUserListQueryHandler : IRequestHandler<GetSystemUserListQuery, List<SystemUser>>
    {
        private readonly ApplicationDbContext _context;

        public GetSystemUserListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SystemUser>> Handle(GetSystemUserListQuery request, CancellationToken cancellationToken)
        {
            return await _context.SystemUsers
                .ToListAsync(cancellationToken);
        }
    }
}