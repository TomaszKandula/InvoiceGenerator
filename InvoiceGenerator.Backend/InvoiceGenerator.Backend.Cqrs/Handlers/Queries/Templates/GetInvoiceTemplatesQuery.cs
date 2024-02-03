using System.Collections.Generic;
using InvoiceGenerator.Services.TemplateService.Models;
using MediatR;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates;

public class GetInvoiceTemplatesQuery : IRequest<IEnumerable<InvoiceTemplateInfo>> { }