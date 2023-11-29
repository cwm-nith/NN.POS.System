namespace NN.POS.Model.Enums;

public class BusinessPartnerEnum
{
    public enum ContactType
    {
        None = 0,
        Supplier = 1,
        Customer = 2,
        SupplierCustomer = 3,
    }

    public enum BusinessType
    {
        None = 0,
        Individual = 1,
        Business = 2,
    }
}