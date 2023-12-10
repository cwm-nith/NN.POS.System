using MediatR;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.App.Commands.UnitOfMeasures;

public class UpdateUomDefineCommand(int id, CreateUomDefineDto dto) : IRequest
{
    public int Id => id;
    public CreateUomDefineDto Dto => dto;
}