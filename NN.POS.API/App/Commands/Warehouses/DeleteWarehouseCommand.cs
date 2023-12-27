using MediatR;

namespace NN.POS.API.App.Commands.Warehouses;

public class DeleteWarehouseCommand(int id) : IRequest
{
    public int Id => id;
}