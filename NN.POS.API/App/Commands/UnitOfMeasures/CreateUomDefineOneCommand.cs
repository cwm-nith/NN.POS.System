using MediatR;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.App.Commands.UnitOfMeasures;

public class CreateUomDefineOneCommand(CreateUomDefineDto dto) : IRequest
{
    public CreateUomDefineDto Dto => dto;
}