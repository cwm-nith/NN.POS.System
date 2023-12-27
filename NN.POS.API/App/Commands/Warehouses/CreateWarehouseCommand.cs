using MediatR;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.App.Commands.Warehouses;

public class CreateWarehouseCommand(CreateWarehouseDto dto) : IRequest
{
    public CreateWarehouseDto Dto => dto;
}