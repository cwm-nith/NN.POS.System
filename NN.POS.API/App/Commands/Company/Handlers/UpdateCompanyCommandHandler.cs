using MediatR;
using NN.POS.API.Core.IRepositories.Company;

namespace NN.POS.API.App.Commands.Company.Handlers;

public class UpdateCompanyCommandHandler(ICompanyRepository repository) : IRequestHandler<UpdateCompanyCommand>
{
    public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var com = await repository.GetByIdAsync(request.Id, cancellationToken);

        var r = request.Dto;

        com.Address = r.Address;
        com.Location = r.Location;
        com.Name = r.Name;
        com.LocalCcyId = r.LocalCcyId;
        com.PriceListId = r.PriceListId;
        com.SysCcyId = r.SysCcyId;

        await repository.UpdateAsync(com, cancellationToken);
    }
}
