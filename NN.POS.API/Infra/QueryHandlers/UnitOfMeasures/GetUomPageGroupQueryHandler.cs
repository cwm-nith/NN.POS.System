using MediatR;
using NN.POS.API.App.Queries.UnitOfMeasures;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Infra.QueryHandlers.UnitOfMeasures;

public class GetUomPageGroupQueryHandler(IUnitOfMeasureGroupRepository repository) : IRequestHandler<GetUomPageGroupQuery, PagedResult<UnitOfMeasureGroupDto>>
{
    public async Task<PagedResult<UnitOfMeasureGroupDto>> Handle(GetUomPageGroupQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}