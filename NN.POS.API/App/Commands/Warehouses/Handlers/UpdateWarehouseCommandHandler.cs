using MediatR;
using NN.POS.API.Core.IRepositories.Warehouses;

namespace NN.POS.API.App.Commands.Warehouses.Handlers;

public class UpdateWarehouseCommandHandler(IWarehouseRepository repository) : IRequestHandler<UpdateWarehouseCommand>
{
    public async Task Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var ws = await repository.GetByIdAsync(request.Id, cancellationToken);

        var r = request.Dto;

        ws.Address = r.Address ?? ws.Address;
        ws.Location = r.Location ?? ws.Location;
        ws.Name = r.Name ?? ws.Name;
        ws.StockIn = r.StockIn;
        ws.BranchId = r.BranchId;

        await repository.UpdateAsync(ws, cancellationToken);
    }
}