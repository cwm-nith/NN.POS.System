using MediatR;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.App.Queries.UnitOfMeasures;

public class GetUomDefineByUomGroupIdQuery(int id) : IRequest<IEnumerable<UnitOfMeasureDefineDto>>
{
    public int Id => id;
}