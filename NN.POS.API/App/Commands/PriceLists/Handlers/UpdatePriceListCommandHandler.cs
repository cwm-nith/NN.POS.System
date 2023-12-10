using MediatR;
using NN.POS.API.Core.IRepositories.PriceLists;

namespace NN.POS.API.App.Commands.PriceLists.Handlers;

public class UpdatePriceListCommandHandler(IPriceListRepository repository) : IRequestHandler<UpdatePriceListCommand>
{
    public async Task Handle(UpdatePriceListCommand request, CancellationToken cancellationToken)
    {
        await repository.UpdateAsync(request.Name, request.Id, cancellationToken);
    }
}