using System.Runtime.Serialization;
using InvoiceGenerator.Backend.Core.Converters;
using Newtonsoft.Json;

namespace InvoiceGenerator.Backend.Domain.Enums;

[JsonConverter(typeof(StringToEnumWithDefaultConverter))]
public enum PaymentTypes
{
    [EnumMember(Value = "unknown")]
    Unknown = 0,

    [EnumMember(Value = "credit card")]
    CreditCard = 1,

    [EnumMember(Value = "wire transfer")]
    WireTransfer = 2
}