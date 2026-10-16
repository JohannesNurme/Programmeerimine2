using System.Collections.Generic;
using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Invoices
{
    public class GetInvoiceListQuery : IRequest<List<Invoice>>
    {
    }
}