using System.Runtime.Serialization;
using InvoiceGenerator.Backend.Core.Converters;
using Newtonsoft.Json;

namespace InvoiceGenerator.Backend.Domain.Enums;

[JsonConverter(typeof(StringToEnumWithDefaultConverter))]
public enum ProcessingStatuses
{
    [EnumMember(Value = "unknown")]
    Unknown = 0,

    [EnumMember(Value = "new")]
    New = 1,

    [EnumMember(Value = "started")]
    Started = 2,

    [EnumMember(Value = "finished")]
    Finished = 3,

    [EnumMember(Value = "failed")]
    Failed = 4
}