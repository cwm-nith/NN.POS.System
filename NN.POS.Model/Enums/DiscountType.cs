using System.Runtime.Serialization;

namespace NN.POS.Model.Enums;

public enum DiscountType
{
    [EnumMember(Value = "PERCENTAGE")]
    Percentage = 1,

    [EnumMember(Value = "FLAT")]
    Flat = 2
}