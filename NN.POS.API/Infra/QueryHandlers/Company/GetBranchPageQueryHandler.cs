using MediatR;
using NN.POS.API.App.Queries.Company;
using NN.POS.API.Core.IRepositories.Company;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Company.Branches;

namespace NN.POS.API.Infra.QueryHandlers.Company;

public class GetBranchPageQueryHandler(IBranchRepository repository) : IRequestHandler<GetBranchPageQuery, PagedResult<BranchDto>>
{
    public async Task<PagedResult<BranchDto>> Handle(GetBranchPageQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}