using MediatR;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.App.Queries.UnitOfMeasures;

public class GetUomDefineByIdQuery(int id) : IRequest<UnitOfMeasureDefineDto>
{
    public int Id => id;
}