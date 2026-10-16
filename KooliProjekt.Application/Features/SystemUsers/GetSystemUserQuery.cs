using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.SystemUsers
{
    public class GetSystemUserQuery : IRequest<SystemUser>
    {
        public int Id { get; set; }
    }
}