using MediatR;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.App.Commands.UnitOfMeasures;

public class CreateUomDefineCommand(List<CreateUomDefineDto> dto) : IRequest
{
    public List<CreateUomDefineDto> Dto => dto;
}