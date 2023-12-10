using MediatR;
using NN.POS.API.App.Queries.UnitOfMeasures;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Infra.QueryHandlers.UnitOfMeasures;

public class GetUomByIdQueryHandler(IUnitOfMeasureRepository repository) : IRequestHandler<GetUomByIdQuery, UnitOfMeasureDto>
{
    public async Task<UnitOfMeasureDto> Handle(GetUomByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id, cancellationToken);
    }
}