namespace InvoiceGenerator.Backend.BatchService.Models
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class FileResult
    {
        public byte[] ContentData { get; set; }

        public string ContentType { get; set; }
    }
}