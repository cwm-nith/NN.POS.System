using MediatR;
using NN.POS.Model.Dtos.ItemMasters;

namespace NN.POS.API.App.Queries.ItemMasters;

public class GetItemMasterDataByIdQuery(int id) : IRequest<ItemMasterDataDto>
{
    public int Id => id;
}