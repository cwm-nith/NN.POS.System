using MediatR;
using NN.POS.API.Core.IRepositories.Company;

namespace NN.POS.API.App.Commands.Company.Handlers;

public class DeleteCompanyCommandHandler(ICompanyRepository repository) : IRequestHandler<DeleteCompanyCommand>
{
    public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id, cancellationToken);
    }
}