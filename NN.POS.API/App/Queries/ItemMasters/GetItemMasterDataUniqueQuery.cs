using MediatR;
using NN.POS.Model.Dtos.ItemMasters;

namespace NN.POS.API.App.Queries.ItemMasters;

public class GetItemMasterDataUniqueQuery(GeyItemMasterDataUniqueDto q) : IRequest<ItemMasterDataDto>
{
    public GeyItemMasterDataUniqueDto Q => q;
}