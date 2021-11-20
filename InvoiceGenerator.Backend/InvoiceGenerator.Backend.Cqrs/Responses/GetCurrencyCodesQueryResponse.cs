namespace InvoiceGenerator.Backend.Cqrs.Responses
{
    public class GetCurrencyCodesQueryResponse
    {
        public int SystemCode { get; set; }

        public string Currency { get; set; }
    }
}