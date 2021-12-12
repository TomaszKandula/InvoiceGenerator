namespace InvoiceGenerator.Backend.Domain.Enums
{
    using System.Runtime.Serialization;

    public enum ProcessingStatuses
    {
        [EnumMember(Value = "unknown")]
        Unknown,

        [EnumMember(Value = "new")]
        New,

        [EnumMember(Value = "started")]
        Started,

        [EnumMember(Value = "finished")]
        Finished,

        [EnumMember(Value = "failed")]
        Failed
    }
}