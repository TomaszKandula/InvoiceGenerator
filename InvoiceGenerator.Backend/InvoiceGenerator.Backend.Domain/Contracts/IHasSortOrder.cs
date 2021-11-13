namespace InvoiceGenerator.Backend.Domain.Contracts
{
    public interface IHasSortOrder
    {
        public int SortOrder { get; set; }
    }
}
