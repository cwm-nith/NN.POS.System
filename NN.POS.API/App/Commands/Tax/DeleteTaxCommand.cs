using MediatR;

namespace NN.POS.API.App.Commands.Tax;

public class DeleteTaxCommand(int id) : IRequest
{
    public int Id => id;
}