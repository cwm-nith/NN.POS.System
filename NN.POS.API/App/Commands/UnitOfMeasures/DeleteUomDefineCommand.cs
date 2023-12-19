using MediatR;

namespace NN.POS.API.App.Commands.UnitOfMeasures;

public class DeleteUomDefineCommand(int id) : IRequest
{
    public int Id => id;
}