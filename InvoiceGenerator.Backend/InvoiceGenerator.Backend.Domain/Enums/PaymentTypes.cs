namespace InvoiceGenerator.Backend.Domain.Enums
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Core.Converters;

    [JsonConverter(typeof(StringToEnumWithDefaultConverter))]
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