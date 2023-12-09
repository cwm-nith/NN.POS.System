using MediatR;
using NN.POS.API.App.Queries.UnitOfMeasures;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Infra.QueryHandlers.UnitOfMeasures;

public class GetUomPageQueryHandler(IUnitOfMeasureRepository repository) : IRequestHandler<GetUomPageQuery, PagedResult<UnitOfMeasureDto>>
{
    public async Task<PagedResult<UnitOfMeasureDto>> Handle(GetUomPageQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}