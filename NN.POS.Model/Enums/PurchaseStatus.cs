using System.Runtime.Serialization;

namespace NN.POS.Model.Enums;

public enum PurchaseStatus
{
    [EnumMember(Value = "CLOSE")]
    Close = 1,

    [EnumMember(Value = "OPEN")]
    Open = 2,
}