using MediatR;
using NN.POS.API.Core.IRepositories.ItemMasters;

namespace NN.POS.API.App.Commands.ItemMasterData.Handlers;

public class UpdateItemMasterDataCommandHandler(IItemMasterDataRepository repository) : IRequestHandler<UpdateItemMasterDataCommand>
{
    public async Task Handle(UpdateItemMasterDataCommand request, CancellationToken cancellationToken)
    {
        await repository.UpdateByIdAsync(request.Id, request.Dto, cancellationToken);
    }
}