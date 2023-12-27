using MediatR;
using NN.POS.API.Core.IRepositories.Warehouses;

namespace NN.POS.API.App.Commands.Warehouses.Handlers;

public class DeleteWarehouseCommandHandler(IWarehouseRepository repository) : IRequestHandler<DeleteWarehouseCommand>
{
    public async Task Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id, cancellationToken);
    }
}