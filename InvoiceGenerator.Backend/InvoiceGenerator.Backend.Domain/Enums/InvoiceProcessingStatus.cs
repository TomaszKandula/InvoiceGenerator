namespace InvoiceGenerator.Backend.Domain.Enums
{
    public enum InvoiceProcessingStatus
    {
        NEW,
        INVOICE_GENERATING_STARTED,
        INVOICE_GENERATING_FINISHED,
        FAILED
    }
}