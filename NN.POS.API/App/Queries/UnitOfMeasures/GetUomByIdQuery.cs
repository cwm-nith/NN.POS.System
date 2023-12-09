using MediatR;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.App.Queries.UnitOfMeasures;

public class GetUomByIdQuery(int id) : IRequest<UnitOfMeasureDto>
{
    public int Id => id;
}