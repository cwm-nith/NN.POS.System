using MediatR;
using NN.POS.API.App.Queries.ItemMasters;
using NN.POS.API.Core.IRepositories.ItemMasters;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.Model.Dtos.Purchases;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.QueryHandlers.ItemMasters;

public class GetPurchaseItemQueryHandler(IItemMasterDataRepository itemRepository, IUnitOfMeasureDefineRepository uomDefineRepository) : IRequestHandler<GetPurchaseItemQuery, PurchaseItemDto>
{
    public async Task<PurchaseItemDto> Handle(GetPurchaseItemQuery request, CancellationToken cancellationToken)
    {
        var item = await itemRepository.GetByIdAsync(request.ItemId, cancellationToken);
        var uomDefines = await uomDefineRepository.GetUomDefineByGroupIdAsync(item.UomGroupId);
        
        return new PurchaseItemDto
        {
            Barcode = item.Barcode,
            Code = item.Code,
            OtherName = item.OtherName ?? "",
            DiscountType = DiscountType.Percentage,
            DiscountValue = 0,
            Id = item.Id,
            Name = item.Name,
            PurchasePrice = 0,
            Qty = 1,
            Total = 0,
            UomId = item.PurchaseUomId ?? 0,
            Uoms = uomDefines.ToList(),
            UomGroupId = item.UomGroupId
        };
    }
}