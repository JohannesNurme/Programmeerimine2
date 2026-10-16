using System.Collections.Generic;
using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.EventFiles
{
    public class GetEventFileListQuery : IRequest<List<EventFile>>
    {
    }
}