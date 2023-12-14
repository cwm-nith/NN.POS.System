using MediatR;
using NN.POS.API.Core.IRepositories.ItemMasters;

namespace NN.POS.API.App.Commands.ItemMasterData.Handlers;

public class DeleteItemMasterDataCommandHandler(IItemMasterDataRepository repository) : IRequestHandler<DeleteItemMasterDataCommand>
{
    public async Task Handle(DeleteItemMasterDataCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id, cancellationToken);
    }
}