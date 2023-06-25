using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Enums;

namespace NN.POS.System.API.Core.Dtos.BusinessPartners;

public class GetBusinessPartnerDto : PagedQuery
{
    /// <summary>
    /// 0: None, 1: Individual, 2: Business
    /// </summary>
    public BusinessPartnerEnum.BusinessType BusinessType { get; set; }

    /// <summary>
    /// 0: None, 1: Supplier, 2: Customer, 3: SupplierCustomer
    /// </summary>
    public BusinessPartnerEnum.ContactType ContactType { get; set; }
}