namespace InvoiceGenerator.Backend.Shared.Dto;

using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

[ExcludeFromCodeCoverage]
public class AddInvoiceTemplateDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    [DataType(DataType.Upload)]
    public IFormFile Data { get; set; }
}