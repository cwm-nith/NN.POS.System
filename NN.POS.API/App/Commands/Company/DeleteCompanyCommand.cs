using MediatR;

namespace NN.POS.API.App.Commands.Company;

public class DeleteCompanyCommand(int id) : IRequest
{
    public int Id => id;
}