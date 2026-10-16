using System.Collections.Generic;
using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Payments
{
    public class GetPaymentListQuery : IRequest<List<Payment>>
    {
    }
}