using System.Runtime.Serialization;

namespace NN.POS.Model.Enums;

public enum TaxType
{
    [EnumMember(Value = "NONE")]
    None = 0,

    [EnumMember(Value = "FLAT")]
    Flat = 1,

    [EnumMember(Value = "PERCENTAGE")]
    Percentage = 2
}