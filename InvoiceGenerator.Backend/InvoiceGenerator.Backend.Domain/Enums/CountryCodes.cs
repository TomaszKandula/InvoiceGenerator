namespace InvoiceGenerator.Backend.Domain.Enums
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Core.Converters;

    [JsonConverter(typeof(StringToEnumWithDefaultConverter))]
    public enum CountryCodes
    {
        [EnumMember(Value = "unknown")]
        Unknown,

        [EnumMember(Value = "austria")]
        Austria,

        [EnumMember(Value = "belgium")]
        Belgium,

        [EnumMember(Value = "bulgaria")]
        Bulgaria,

        [EnumMember(Value = "croatia")]
        Croatia,

        [EnumMember(Value = "cyprus")]
        Cyprus,

        [EnumMember(Value = "czech")]
        Czech,

        [EnumMember(Value = "denmark")]
        Denmark,

        [EnumMember(Value = "estonia")]
        Estonia,

        [EnumMember(Value = "finland")]
        Finland,

        [EnumMember(Value = "france")]
        France,

        [EnumMember(Value = "germany")]
        Germany,

        [EnumMember(Value = "greece")]
        Greece,

        [EnumMember(Value = "hungary")]
        Hungary,

        [EnumMember(Value = "ireland")]
        Ireland,

        [EnumMember(Value = "italy")]
        Italy,

        [EnumMember(Value = "latvia")]
        Latvia,

        [EnumMember(Value = "lithuania")]
        Lithuania,

        [EnumMember(Value = "luxembourg")]
        Luxembourg,

        [EnumMember(Value = "malta")]
        Malta,

        [EnumMember(Value = "netherlands")]
        Netherlands,

        [EnumMember(Value = "poland")]
        Poland,

        [EnumMember(Value = "portugal")]
        Portugal,

        [EnumMember(Value = "romania")]
        Romania,

        [EnumMember(Value = "slovakia")]
        Slovakia,

        [EnumMember(Value = "slovenia")]
        Slovenia,

        [EnumMember(Value = "spain")]
        Spain,

        [EnumMember(Value = "sweden")]
        Sweden,
        
        [EnumMember(Value = "usa")]
        Usa,
        
        [EnumMember(Value = "china")]
        China
    }
}