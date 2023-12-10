using MediatR;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.App.Queries.UnitOfMeasures;

public class GetUomGroupByIdQuery(int id) : IRequest<UnitOfMeasureGroupDto>
{
    public int Id => id;
}