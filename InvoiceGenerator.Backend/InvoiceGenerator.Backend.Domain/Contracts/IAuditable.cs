namespace InvoiceGenerator.Backend.Domain.Contracts
{
	using System;

	public interface IAuditable
	{
		string CreatedBy { get; set; }
		DateTime CreatedAt { get; set; }

		string ModifiedBy { get; set; }
		DateTime ModifiedAt { get; set; }
	}
}
  