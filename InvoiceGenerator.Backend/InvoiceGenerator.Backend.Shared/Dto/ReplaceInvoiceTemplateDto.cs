namespace InvoiceGenerator.Backend.Shared.Dto;

using System;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Shared.Models;

[ExcludeFromCodeCoverage]
public class ReplaceInvoiceTemplateDto : RequestProperties
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    [DataType(DataType.Upload)]
    public IFormFile Data { get; set; }
}