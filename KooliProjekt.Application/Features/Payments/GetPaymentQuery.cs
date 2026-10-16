using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Payments
{
    public class GetPaymentQuery : IRequest<Payment>
    {
        public int Id { get; set; }
    }
}