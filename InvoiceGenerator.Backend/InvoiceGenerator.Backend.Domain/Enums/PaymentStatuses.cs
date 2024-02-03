using System.Runtime.Serialization;
using InvoiceGenerator.Backend.Core.Converters;
using Newtonsoft.Json;

namespace InvoiceGenerator.Backend.Domain.Enums;

[JsonConverter(typeof(StringToEnumWithDefaultConverter))]
public enum PaymentStatuses
{
    [EnumMember(Value = "unknown")]
    Unknown = 0,

    [EnumMember(Value = "unpaid")]
    Unpaid = 1,

    [EnumMember(Value = "partially paid")]
    PartiallyPaid = 2,

    [EnumMember(Value = "paid")]
    Paid = 3
}