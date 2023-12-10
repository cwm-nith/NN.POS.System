using MediatR;
using NN.POS.API.Core.IRepositories.PriceLists;

namespace NN.POS.API.App.Commands.PriceLists.Handlers;

public class DeletePriceListCommandHandler(IPriceListRepository repository) : IRequestHandler<DeletePriceListCommand>
{
    public async Task Handle(DeletePriceListCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id, cancellationToken);
    }
}