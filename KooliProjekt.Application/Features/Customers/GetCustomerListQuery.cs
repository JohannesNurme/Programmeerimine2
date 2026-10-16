using System.Collections.Generic;
using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Customers
{
    public class GetCustomerListQuery : IRequest<List<Customer>>
    {
    }
}