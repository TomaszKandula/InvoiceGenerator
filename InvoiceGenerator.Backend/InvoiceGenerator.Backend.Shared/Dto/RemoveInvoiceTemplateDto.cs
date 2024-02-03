using System;
using System.Diagnostics.CodeAnalysis;

namespace InvoiceGenerator.Backend.Shared.Dto;

[ExcludeFromCodeCoverage]
public class RemoveInvoiceTemplateDto
{
    public Guid Id { get; set; }        
}