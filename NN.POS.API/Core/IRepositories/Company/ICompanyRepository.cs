using NN.POS.API.App.Queries.Company;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Company;

namespace NN.POS.API.Core.IRepositories.Company;

public interface ICompanyRepository : IRepository
{
    Task CreateAsync(CompanyDto body, CancellationToken cancellationToken = default);
    Task UpdateAsync(CompanyDto body, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<CompanyDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PagedResult<CompanyDto>> GetPageAsync(GetCompanyPageQuery query, CancellationToken cancellationToken = default);
}