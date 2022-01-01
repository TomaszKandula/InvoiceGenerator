namespace InvoiceGenerator.Services.TemplateService.Models;

using System;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class InvoiceTemplateInfo
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}