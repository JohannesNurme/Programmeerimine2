using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.EventFiles
{
    public class GetEventFileQuery : IRequest<EventFile>
    {
        public int Id { get; set; }
    }
}