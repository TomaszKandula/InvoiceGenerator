namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates;

using MediatR;
using System.Collections.Generic;
using Services.TemplateService.Models;

public class GetInvoiceTemplatesQuery : IRequest<IEnumerable<InvoiceTemplateInfo>> { }