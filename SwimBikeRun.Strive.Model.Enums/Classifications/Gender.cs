using System.Runtime.Serialization;

namespace SwimBikeRun.Strive.Model.Enums.Classifications
{
    public enum Gender
    {
        [EnumMember(Value = "U")]
        Unknown,
        [EnumMember(Value = "M")]
        Male,
        [EnumMember(Value = "F")]
        Female,
        [EnumMember(Value = "B")]
        Both = Male & Female
    }
}