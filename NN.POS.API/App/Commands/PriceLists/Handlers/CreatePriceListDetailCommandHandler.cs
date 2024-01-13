using MediatR;
using NN.POS.API.Core.IRepositories.ItemMasters;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.App.Commands.PriceLists.Handlers;

public class CreatePriceListDetailCommandHandler(
    IPriceListDetailRepository repository, 
    IItemMasterDataRepository itemRepository,
    IUnitOfMeasureDefineRepository uomDefineRepository) : IRequestHandler<CreatePriceListDetailCommand>
{
    public async Task Handle(CreatePriceListDetailCommand request, CancellationToken cancellationToken)
    {
        var plds = new List<PriceListDetailDto>();

        foreach (var pld in request.Dto)
        {
            var item = await itemRepository.GetByIdAsync(pld.ItemId, cancellationToken);
            var uomDefines = (await uomDefineRepository.GetUomDefineByGroupIdAsync(item.UomGroupId))
                .Where(i => i.AltUomId != pld.UomId).ToList();

            plds.Add(new PriceListDetailDto
            {
                CcyId = pld.CcyId,
                Price = pld.Price,
                Cost = pld.Cost,
                CreatedAt = DateTime.UtcNow,
                DiscountType = pld.DiscountType,
                DiscountValue = pld.DiscountValue,
                Id = 0,
                ItemId = pld.ItemId,
                PriceListId = pld.PriceListId,
                PromotionId = pld.PromotionId,
                UomId = pld.UomId
            });

            plds.AddRange(uomDefines.Select(uom => new PriceListDetailDto
            {
                CcyId = pld.CcyId,
                Price = pld.Price * uom.Factor,
                Cost = pld.Cost * uom.Factor,
                CreatedAt = DateTime.UtcNow,
                DiscountType = pld.DiscountType,
                DiscountValue = pld.DiscountValue,
                Id = 0,
                ItemId = pld.ItemId,
                PriceListId = pld.PriceListId,
                PromotionId = pld.PromotionId,
                UomId = uom.AltUomId
            }));
        }

        await repository.CreateAsync(plds, cancellationToken);
    }
}