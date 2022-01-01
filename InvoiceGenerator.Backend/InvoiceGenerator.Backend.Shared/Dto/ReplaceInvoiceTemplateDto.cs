namespace InvoiceGenerator.Backend.Shared.Dto;

using System;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

[ExcludeFromCodeCoverage]
public class ReplaceInvoiceTemplateDto
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    [DataType(DataType.Upload)]
    public IFormFile Data { get; set; }
}