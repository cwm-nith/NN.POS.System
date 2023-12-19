using MediatR;
using NN.POS.API.App.Queries.UnitOfMeasures;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Infra.QueryHandlers.UnitOfMeasures;

public class GetUomDefineByUomGroupIdQueryHandler(IUnitOfMeasureDefineRepository repository) : IRequestHandler<GetUomDefineByUomGroupIdQuery, IEnumerable<UnitOfMeasureDefineDto>>
{
    public async Task<IEnumerable<UnitOfMeasureDefineDto>> Handle(GetUomDefineByUomGroupIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetUomDefineByGroupIdAsync(request.Id);
    }
}