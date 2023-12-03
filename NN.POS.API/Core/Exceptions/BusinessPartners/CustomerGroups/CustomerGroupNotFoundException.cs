namespace NN.POS.API.Core.Exceptions.BusinessPartners.CustomerGroups;

public class CustomerGroupNotFoundException() : BaseException("Customer group not found")
{
    public override string Code => "CUS_GP_NF";
}