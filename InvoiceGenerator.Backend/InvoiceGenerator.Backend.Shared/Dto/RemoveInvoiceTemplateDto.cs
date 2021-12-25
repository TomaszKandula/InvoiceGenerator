namespace InvoiceGenerator.Backend.Shared.Dto;

using System;
using Shared.Models;

public class RemoveInvoiceTemplateDto : RequestProperties
{
    public Guid Id { get; set; }        
}