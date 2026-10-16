using System.Collections.Generic;
using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Events
{
    public class GetEventListQuery : IRequest<List<Event>>
    {
    }
}