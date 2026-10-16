using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Registrations
{
    public class GetRegistrationQuery : IRequest<Registration>
    {
        public int Id { get; set; }
    }
}