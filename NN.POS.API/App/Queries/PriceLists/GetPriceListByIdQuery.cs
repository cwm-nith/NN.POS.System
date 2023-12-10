using MediatR;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.App.Queries.PriceLists;

public class GetPriceListByIdQuery(int id) : IRequest<PriceListDto>
{
    public int Id => id;
}