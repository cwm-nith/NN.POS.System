using MediatR;

namespace NN.POS.API.App.Commands.UnitOfMeasures;

public class UpdateUomGroupCommand(int id, string? name) : IRequest
{
    public int Id => id;
    public string? Name => name;
}