using MediatR;
using NN.POS.API.Core.IRepositories.Company;

namespace NN.POS.API.App.Commands.Company.Handlers;

public class UpdateBranchCommandHandler(IBranchRepository repository) : IRequestHandler<UpdateBranchCommand>
{
    public async Task Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var br = await repository.GetByIdAsync(request.Id, cancellationToken);

        var r = request.Dto;

        br.Address = r.Address;
        br.Location = r.Location;
        br.Name = r.Name;
        br.CompanyId = r.CompanyId;

        await repository.UpdateAsync(br, cancellationToken);
    }
}