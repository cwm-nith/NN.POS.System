using System.Runtime.Serialization;

namespace NN.POS.Model.Enums;

public enum DocumentInvoicingType
{
    [EnumMember(Value = "PURCHASE_ORDER")]
    PurchaseOrder = 1,

    [EnumMember(Value = "PURCHASE_PO")]
    PurchasePO = 2,

    [EnumMember(Value = "PURCHASE_AP")]
    PurchaseAP = 3
}