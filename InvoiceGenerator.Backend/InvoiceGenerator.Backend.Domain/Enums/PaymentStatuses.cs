namespace InvoiceGenerator.Backend.Domain.Enums;

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Core.Converters;

[JsonConverter(typeof(StringToEnumWithDefaultConverter))]
public enum PaymentStatuses
{
    [EnumMember(Value = "unknown")]
    Unknown,

    [EnumMember(Value = "unpaid")]
    Unpaid,

    [EnumMember(Value = "partially paid")]
    PartiallyPaid,

    [EnumMember(Value = "paid")]
    Paid
}