using MediatR;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.App.Queries.UnitOfMeasures;

public class GetUomByGroupIdQuery : IRequest<List<UnitOfMeasureDto>>
{
    public string? Search { get; set; }
    public int GroupId { get; set; }
}