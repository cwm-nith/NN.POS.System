using MediatR;
using NN.POS.API.Core.IRepositories.ItemMasters;
using NN.POS.Model.Dtos.ItemMasters;

namespace NN.POS.API.App.Commands.ItemMasterData.Handlers;

public class CreateItemMasterDataCommandHandler(IItemMasterDataRepository repository) : IRequestHandler<CreateItemMasterDataCommand>
{
    public async Task Handle(CreateItemMasterDataCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        var dto = new ItemMasterDataDto
        {
            Code = r.Code,
            Barcode = r.Barcode,
            Name = r.Name,
            OtherName = r.OtherName,
            StockIn = r.StockIn,
            StockCommit = r.StockCommit,
            StockOnHand = r.StockOnHand,
            BaseUomId = r.BaseUomId,
            PriceListId = r.PriceListId,
            UomGroupId = r.UomGroupId,
            PurchaseUomId = r.PurchaseUomId,
            SaleUomId = r.SaleUomId,
            InventoryUoMid = r.InventoryUoMid,
            WarehouseId = r.WarehouseId,
            Type = r.Type,
            IsInventory = r.IsInventory,
            IsSale = r.IsSale,
            IsPurchase = r.IsPurchase,
            Image = r.Image,
            Description = r.Description,
            Process = r.Process,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
        };
        await repository.CreateAsync(dto, cancellationToken);
    }
}