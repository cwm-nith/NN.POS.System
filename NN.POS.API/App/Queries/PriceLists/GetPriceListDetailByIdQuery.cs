using MediatR;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.App.Queries.PriceLists;

public class GetPriceListDetailByIdQuery(int id) : IRequest<PriceListDetailDto>
{
    public int Id => id;
}