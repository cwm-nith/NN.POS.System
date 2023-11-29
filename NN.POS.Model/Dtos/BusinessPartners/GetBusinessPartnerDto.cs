using NN.POS.Common.Pagination;
using NN.POS.Model.Enums;

namespace NN.POS.Model.Dtos.BusinessPartners;

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