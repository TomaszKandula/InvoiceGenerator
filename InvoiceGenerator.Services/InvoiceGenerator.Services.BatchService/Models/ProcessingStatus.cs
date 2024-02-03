using System;
using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Domain.Enums;

namespace InvoiceGenerator.Services.BatchService.Models;

[ExcludeFromCodeCoverage]
public class ProcessingStatus
{
    public TimeSpan? BatchProcessingTime { get; set; }

    public ProcessingStatuses Status { get; set; }

    public DateTime CreatedAt { get; set; }
}