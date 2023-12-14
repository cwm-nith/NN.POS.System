using System.Runtime.Serialization;

namespace NN.POS.Model.Enums;

public class BusinessPartnerEnum
{
    public enum ContactType
    {
        [EnumMember(Value = "NONE")]
        None = 0,

        [EnumMember(Value = "SUPPLIER")]
        Supplier = 1,

        [EnumMember(Value = "CUSTOMER")]
        Customer = 2,

        [EnumMember(Value = "SUPPLIER_AND_CUSTOMER")]
        SupplierCustomer = 3,
    }

    public enum BusinessType
    {
        [EnumMember(Value = "NONE")]
        None = 0,

        [EnumMember(Value = "INDIVIDUAL")]
        Individual = 1,

        [EnumMember(Value = "BUSINESS")]
        Business = 2,
    }
}