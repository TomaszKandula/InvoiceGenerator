namespace InvoiceGenerator.Backend.Domain.Contracts;

public interface IVersionable
{
	int Version { get; set; }
}