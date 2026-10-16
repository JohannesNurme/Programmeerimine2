using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Customers
{
    public class GetCustomerQuery : IRequest<Customer>
    {
        public int Id { get; set; }
    }
}
