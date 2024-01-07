using MediatR;
using NN.POS.API.Core.IRepositories.PriceLists;

namespace NN.POS.API.App.Commands.PriceLists.Handlers;

public class UpdatePriceListDetailCommandHandler(IPriceListDetailRepository repository) : IRequestHandler<UpdatePriceListDetailCommand>
{
    public async Task Handle(UpdatePriceListDetailCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        var pld = await repository.GetByIdAsync(request.Id, cancellationToken);
        pld.Cost = r.Cost;
        pld.Price = r.Price;

        await repository.UpdateAsync(pld, cancellationToken);
    }
}