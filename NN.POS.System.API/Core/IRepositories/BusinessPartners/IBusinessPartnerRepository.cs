using System.Linq.Expressions;
using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Entities.BusinessPartners;
using NN.POS.System.API.Infra.Tables.BusinessPartners;

namespace NN.POS.System.API.Core.IRepositories.BusinessPartners;

public interface IBusinessPartnerRepository
{
    Task<BusinessPartnerEntity> CreateAsync(BusinessPartnerEntity entity, CancellationToken cancellation = default);
    Task UpdateAsync(BusinessPartnerEntity entity, CancellationToken cancellation = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellation = default);

    Task<BusinessPartnerEntity> GetByIdAsync(int id, CancellationToken cancellation = default);
    Task<int> GetCountAsync(CancellationToken cancellation = default);
    Task<PagedResult<BusinessPartnerEntity>> GetAllAsync(Expression<Func<BusinessPartnerTable, bool>> predicate, PagedQuery q, CancellationToken cancellation = default);
}