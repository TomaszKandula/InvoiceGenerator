namespace InvoiceGenerator.Backend.Domain.Enums
{
    public enum InvoiceProcessingStatuses
    {
        New,
        InvoiceGeneratingStarted,
        InvoiceGeneratingFinished,
        Failed
    }
}