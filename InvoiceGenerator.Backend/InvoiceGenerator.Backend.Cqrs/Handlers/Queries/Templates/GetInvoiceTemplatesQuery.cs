namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates;

using MediatR;
using System.Collections.Generic;
using Shared.Models;
using Services.TemplateService.Models;

public class GetInvoiceTemplatesQuery : RequestProperties, IRequest<IEnumerable<InvoiceTemplateInfo>> { }