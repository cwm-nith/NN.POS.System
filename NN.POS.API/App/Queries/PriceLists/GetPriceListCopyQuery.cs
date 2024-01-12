using MediatR;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.App.Queries.PriceLists;

public class GetPriceListCopyQuery(int priceListId, int priceListIdCopyFrom) : IRequest<List<PriceListDetailDto>>
{
    public int PriceListId => priceListId;
    public int PriceListIdCopyFrom => priceListIdCopyFrom;
}