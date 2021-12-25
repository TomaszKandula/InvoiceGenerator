namespace InvoiceGenerator.Backend.Shared.Models;

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public abstract class RequestProperties
{
    public string PrivateKey { get; set; }
}