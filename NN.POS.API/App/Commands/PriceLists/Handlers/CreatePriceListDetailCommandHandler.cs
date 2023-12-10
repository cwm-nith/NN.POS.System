using MediatR;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.App.Commands.PriceLists.Handlers;

public class CreatePriceListDetailCommandHandler(IPriceListDetailRepository repository) : IRequestHandler<CreatePriceListDetailCommand>
{
    public async Task Handle(CreatePriceListDetailCommand request, CancellationToken cancellationToken)
    {
        await repository.CreateAsync(request.Dto.Select(i => new PriceListDetailDto
        {
            CcyId = i.CcyId,
            Price = i.Price,
            Cost = i.Cost,
            CreatedAt = DateTime.UtcNow,
            DiscountType = i.DiscountType,
            DiscountValue = i.DiscountValue,
            Id = 0,
            ItemId = i.ItemId,
            PriceListId = i.PriceListId,
            PromotionId = i.PromotionId,
            UomId = i.UomId
        }).ToList(), cancellationToken);
    }
}