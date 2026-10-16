using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Invoices
{
    public class GetInvoiceQuery : IRequest<Invoice>
    {
        public int Id { get; set; }
    }
}