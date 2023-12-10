using MediatR;

namespace NN.POS.API.App.Commands.UnitOfMeasures;

public class CreateUomCommand : IRequest
{
    public string Name { get; set; } = string.Empty;
}