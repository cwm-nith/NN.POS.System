using MediatR;
using NN.POS.API.Core.IRepositories.Warehouses;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.App.Commands.Warehouses.Handlers;

public class CreateWarehouseCommandHandler(IWarehouseRepository repository) : IRequestHandler<CreateWarehouseCommand>
{
    public async Task Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        var dto = new WarehouseDto
        {
            Name = r.Name ?? "",
            IsDeleted = false,
            Address = r.Address,
            BranchId = r.BranchId,
            BranchName = "",
            Code = r.Code ?? "",
            CreatedAt = DateTime.UtcNow,
            Id = 0,
            Location = r.Location,
            StockIn = r.StockIn
        };

        await repository.CreateAsync(dto, cancellationToken);
    }
}