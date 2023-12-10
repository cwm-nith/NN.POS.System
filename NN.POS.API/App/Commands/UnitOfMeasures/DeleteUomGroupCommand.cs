using MediatR;

namespace NN.POS.API.App.Commands.UnitOfMeasures;

public class DeleteUomGroupCommand(int id) : IRequest
{
    public int Id => id;
}