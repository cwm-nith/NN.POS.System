using MediatR;

namespace NN.POS.API.App.Commands.UnitOfMeasures;

public class DeleteUomCommand : IRequest
{
    public int Id { get; set; }
}