using System.Collections.Generic;
using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Registrations
{
    public class GetRegistrationListQuery : IRequest<List<Registration>>
    {
    }
}