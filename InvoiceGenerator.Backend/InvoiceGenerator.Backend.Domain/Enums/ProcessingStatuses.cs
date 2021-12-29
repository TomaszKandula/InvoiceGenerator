namespace InvoiceGenerator.Backend.Domain.Enums;

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Core.Converters;

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