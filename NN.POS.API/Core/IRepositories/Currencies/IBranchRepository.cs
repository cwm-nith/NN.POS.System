using NN.POS.API.App.Queries.Company;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Company.Branches;

namespace NN.POS.API.Core.IRepositories.Currencies;

public interface IBranchRepository : IRepository
{
    Task CreateAsync(BranchDto body, CancellationToken cancellationToken = default);
    Task UpdateAsync(BranchDto body, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<BranchDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PagedResult<BranchDto>> GetPageAsync(GetBranchPageQuery query, CancellationToken cancellationToken = default);
}