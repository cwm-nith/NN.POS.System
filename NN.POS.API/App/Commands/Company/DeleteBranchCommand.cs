using MediatR;

namespace NN.POS.API.App.Commands.Company;

public class DeleteBranchCommand(int id) : IRequest
{
    public int Id => id;
}