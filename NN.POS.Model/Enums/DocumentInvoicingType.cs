using System.Runtime.Serialization;

namespace NN.POS.Model.Enums;

public enum DocumentInvoicingType
{
    [EnumMember(Value = "PURCHASE_ORDER")]
    PurchaseOrder = 1,

    [EnumMember(Value = "PURCHASE_PO")]
    PurchasePO = 2,

    [EnumMember(Value = "PURCHASE_AP")]
    PurchaseAP = 3,

    [EnumMember(Value = "PURCHASE_CREDIT_MEMO")]
    PurchaseCreditMemo = 4
}