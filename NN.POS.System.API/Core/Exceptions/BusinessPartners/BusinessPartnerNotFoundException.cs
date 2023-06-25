namespace NN.POS.System.API.Core.Exceptions.BusinessPartners;

public class BusinessPartnerNotFoundException : BaseException
{
    public override string Code => "business_partner_not_found";

    public BusinessPartnerNotFoundException(int id) : base($"Business Partner with id \"{id}\" not found!")
    {
        
    }
}