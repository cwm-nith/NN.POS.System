using NN.POS.API.App.Queries.BusinessPartners.CustomerGroups;
using NN.POS.API.Core.Entities.BusinessPartners.CustomerGroups;
using NN.POS.Common.Pagination;

namespace NN.POS.API.Core.IRepositories.BusinessPartners;

public interface ICustomerGroupRepository
{
    Task<PagedResult<CustomerGroupEntity>> GetAsync(GetCustomerGroupsQuery q, CancellationToken cancellationToken = default);
    Task<CustomerGroupEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAsync(CustomerGroupEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}