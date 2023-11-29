namespace NN.POS.API.Core.Exceptions.BusinessPartners;

public class BusinessPartnerNotFoundException(int id) : BaseException($"Business Partner with id \"{id}\" not found!")
{
    public override string Code => "business_partner_not_found";
}