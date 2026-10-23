using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.SystemUsers
{
    public class GetSystemUserListQueryHandler : IRequestHandler<GetSystemUserListQuery, OperationResult<PagedResult<SystemUserDto>>>
    {
        private readonly ApplicationDbContext _context;

        public GetSystemUserListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult<PagedResult<SystemUserDto>>> Handle(GetSystemUserListQuery request, CancellationToken cancellationToken)
        {
            var query = _context.SystemUsers.AsQueryable();

            int totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(u => new SystemUserDto
                {
                    Id = u.Id,
                    Name = u.Email,
                    Email = u.Email
                })
                .ToListAsync(cancellationToken);

            var pagedResult = new PagedResult<SystemUserDto>
            {
                RowCount = totalCount,
                Results = items
            };

            return new OperationResult<PagedResult<SystemUserDto>>
            {
                Value = pagedResult
            };
        }
    }
}