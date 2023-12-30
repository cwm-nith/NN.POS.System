using MediatR;
using NN.POS.API.Core.IRepositories.ItemMasters;
using NN.POS.API.Core.Utils;
using NN.POS.Model.Dtos.ItemMasters;

namespace NN.POS.API.App.Commands.ItemMasterData.Handlers;

public class CreateItemMasterDataCommandHandler(IItemMasterDataRepository repository, IWebHostEnvironment environment) : IRequestHandler<CreateItemMasterDataCommand>
{
    public async Task Handle(CreateItemMasterDataCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;

        var fileName = r.File == null ? "" : $"{Guid.NewGuid()}{Path.GetExtension(r.File?.FileName)}";

        var dto = new ItemMasterDataDto
        {
            Code = StringUtil.GetRandomString(prefix: "item-"),
            Barcode = StringUtil.GetRandomString(prefix: "item-"),
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
            InventoryUoMid = r.InventoryUomId,
            WarehouseId = r.WarehouseId,
            Type = r.Type,
            IsInventory = r.IsInventory,
            IsSale = r.IsSale,
            IsPurchase = r.IsPurchase,
            Image = fileName,
            Description = r.Description,
            Process = r.Process,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
        };
        await repository.CreateAsync(dto, cancellationToken);

        if (r.File != null)
        {
            var uploadsPath = Path.Join(environment.WebRootPath, "contents/item-master/images");
            var filePath = Path.Join(uploadsPath, fileName);
            await using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await fileStream.WriteAsync(r.File.ImageBytes, cancellationToken);
        }
    }
}