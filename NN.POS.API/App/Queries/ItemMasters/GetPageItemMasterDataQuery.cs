using MediatR;
using NN.POS.API.Core.Utils;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.ItemMasters;
using NN.POS.Model.Enums;

namespace NN.POS.API.App.Queries.ItemMasters;

public class GetPageItemMasterDataQuery : PagedQuery, IRequest<PagedResult<ItemMasterDataDto>>
{
    public string? Search { get; set; }
    public ItemMasterDataProcess Process { get; set; }
    public string Type { get; set; } = string.Empty;
    public bool? IsPurchase { get; set; }
    public bool? IsSale { get; set; }
    public int? WsId { get; set; }

    public List<ItemMasterDataType> Types()
    {
        var types = Type.Split(",").Select(x => (ItemMasterDataType)x.ToInt()).ToList();
        return types;
    }
}