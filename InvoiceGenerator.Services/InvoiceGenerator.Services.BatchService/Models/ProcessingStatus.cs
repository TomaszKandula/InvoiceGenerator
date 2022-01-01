namespace InvoiceGenerator.Services.BatchService.Models;

using System;
using System.Diagnostics.CodeAnalysis;
using Backend.Domain.Enums;

[ExcludeFromCodeCoverage]
public class ProcessingStatus
{
    public TimeSpan? BatchProcessingTime { get; set; }

    public ProcessingStatuses Status { get; set; }

    public DateTime CreatedAt { get; set; }
}