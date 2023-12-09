using MediatR;

namespace NN.POS.API.App.Commands.UnitOfMeasures;

public class UpdateUomCommand : IRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
}