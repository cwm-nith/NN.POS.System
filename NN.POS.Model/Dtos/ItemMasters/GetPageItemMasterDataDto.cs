using NN.POS.Model.Enums;
using NN.POS.Common.Pagination;

namespace NN.POS.Model.Dtos.ItemMasters;

public class GetPageItemMasterDataDto : PagedQuery
{
    public string? Search { get; set; }
    public ItemMasterDataProcess Process { get; set; }
    public ItemMasterDataType Type { get; set; }
}