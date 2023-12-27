using MediatR;
using NN.POS.API.App.Queries.Company;
using NN.POS.API.Core.IRepositories.Company;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Company;

namespace NN.POS.API.Infra.QueryHandlers.Company;

public class GetCompanyPageQueryHandler(ICompanyRepository repository) : IRequestHandler<GetCompanyPageQuery, PagedResult<CompanyDto>>
{
    public async Task<PagedResult<CompanyDto>> Handle(GetCompanyPageQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}