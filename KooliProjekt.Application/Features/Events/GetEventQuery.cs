using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Events
{
    public class GetEventQuery : IRequest<Event>
    {
        public int Id { get; set; }
    }
}