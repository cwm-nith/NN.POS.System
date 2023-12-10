using MediatR;

namespace NN.POS.API.App.Commands.UnitOfMeasures;

public class CreateUomGroupCommand(string name) : IRequest
{
    public string Name => name;
}