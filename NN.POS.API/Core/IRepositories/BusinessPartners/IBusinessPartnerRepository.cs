using System.Linq.Expressions;
using NN.POS.API.Core.Entities.BusinessPartners;
using NN.POS.API.Infra.Tables.BusinessPartners;
using NN.POS.Common.Pagination;

namespace NN.POS.API.Core.IRepositories.BusinessPartners;

public interface IBusinessPartnerRepository
{
    Task<BusinessPartnerEntity> CreateAsync(BusinessPartnerEntity entity, CancellationToken cancellation = default);
    Task UpdateAsync(BusinessPartnerEntity entity, CancellationToken cancellation = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellation = default);

    Task<BusinessPartnerEntity> GetByIdAsync(int id, CancellationToken cancellation = default);
    Task<int> GetCountAsync(CancellationToken cancellation = default);
    Task<PagedResult<BusinessPartnerEntity>> GetAllAsync(Expression<Func<BusinessPartnerTable, bool>> predicate, PagedQuery q, CancellationToken cancellation = default);
}