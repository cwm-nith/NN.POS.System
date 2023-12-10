using MediatR;
using NN.POS.API.Core.IRepositories.PriceLists;

namespace NN.POS.API.App.Commands.PriceLists.Handlers;

public class UpdatePriceListDetailCommandHandler(IPriceListDetailRepository repository) : IRequestHandler<UpdatePriceListDetailCommand>
{
    public async Task Handle(UpdatePriceListDetailCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        var pld = await repository.GetByIdAsync(request.Id, cancellationToken);
        pld.CcyId = r.CcyId;
        pld.Cost = r.Cost;
        pld.Price = r.Price;
        pld.DiscountType = r.DiscountType;
        pld.DiscountValue = r.DiscountValue;
        pld.Price = r.Price;
        pld.PromotionId = r.PromotionId;
        pld.UomId = r.UomId;

        await repository.UpdateAsync(pld, cancellationToken);
    }
}