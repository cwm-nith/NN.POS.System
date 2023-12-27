using MediatR;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.App.Commands.Warehouses;

public class UpdateWarehouseCommand(int id, UpdateWarehouseDto dto) : IRequest
{
    public int Id => id;
    public UpdateWarehouseDto Dto => dto;
}