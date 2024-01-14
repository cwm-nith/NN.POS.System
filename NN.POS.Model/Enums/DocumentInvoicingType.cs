using System.Runtime.Serialization;

namespace NN.POS.Model.Enums;

public enum DocumentInvoicingType
{
    [EnumMember(Value = "PURCHASE_ORDER")]
    PurchaseOrder = 1
}