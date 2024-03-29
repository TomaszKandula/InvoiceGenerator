using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;

namespace InvoiceGenerator.Backend.Shared.Dto;

[ExcludeFromCodeCoverage]
public class AddInvoiceTemplateDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    [DataType(DataType.Upload)]
    public IFormFile Data { get; set; }
}