namespace InvoiceGenerator.Backend.Domain.Enums
{
    using System.Runtime.Serialization;

    public enum PaymentTypes
    {
        [EnumMember(Value = "unknown")]
        Unknown,

        [EnumMember(Value = "credit card")]
        CreditCard,

        [EnumMember(Value = "wire transfer")]
        WireTransfer
    }
}