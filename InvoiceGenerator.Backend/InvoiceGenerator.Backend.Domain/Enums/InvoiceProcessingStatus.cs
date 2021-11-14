namespace InvoiceGenerator.Backend.Domain.Enums
{
    public enum InvoiceProcessingStatus
    {
        New,
        InvoiceGeneratingStarted,
        InvoiceGeneratingFinished,
        Failed
    }
}