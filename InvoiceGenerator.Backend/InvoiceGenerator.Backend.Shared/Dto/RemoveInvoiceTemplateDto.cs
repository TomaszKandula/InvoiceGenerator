namespace InvoiceGenerator.Backend.Shared.Dto;

using System;
using Shared.Models;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class RemoveInvoiceTemplateDto : RequestProperties
{
    public Guid Id { get; set; }        
}