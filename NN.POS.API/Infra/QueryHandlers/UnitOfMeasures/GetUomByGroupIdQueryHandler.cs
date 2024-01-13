using MediatR;
using NN.POS.API.App.Queries.UnitOfMeasures;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Infra.QueryHandlers.UnitOfMeasures;

public class GetUomByGroupIdQueryHandler(IUnitOfMeasureDefineRepository repository) : IRequestHandler<GetUomByGroupIdQuery, List<UnitOfMeasureDto>>
{
    public async Task<List<UnitOfMeasureDto>> Handle(GetUomByGroupIdQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetUomDefineByGroupIdAsync(request.GroupId);
        return data.Select(i => new UnitOfMeasureDto
        {
            Id = i.AltUomId,
            Name = i.AltUomName ?? ""
        }).Where(i => string.IsNullOrEmpty(request.Search) || i.Name.Contains(request.Search, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}