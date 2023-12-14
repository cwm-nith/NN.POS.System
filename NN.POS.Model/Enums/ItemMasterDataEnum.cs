using System.Runtime.Serialization;

namespace NN.POS.Model.Enums;

public enum ItemMasterDataType
{
    [EnumMember(Value = "NONE")]
    None = 0,

    [EnumMember(Value = "GROUP")]
    Group = 1,

    [EnumMember(Value = "ITEM")]
    Item = 2,

    [EnumMember(Value = "SERVICE")]
    Service = 3,

    [EnumMember(Value = "LABOR")]
    Labor = 4
}

public enum ItemMasterDataProcess
{
    [EnumMember(Value = "NONE")]
    None = 0,

    [EnumMember(Value = "FIFO")]
    Fifo = 1,

    [EnumMember(Value = "AVERAGE")]
    Average = 2,
    
    [EnumMember(Value = "STANDARD")]
    Standard = 3
}