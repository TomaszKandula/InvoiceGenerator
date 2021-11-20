namespace InvoiceGenerator.Backend.Cqrs.Responses
{
    public class GetCountryCodesQueryResponse
    {
        public int SystemCode { get; set; }

        public string Country { get; set; }
    }
}