using System.Collections.Generic;
using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.SystemUsers
{
    public class GetSystemUserListQuery : IRequest<List<SystemUser>>
    {
    }
}