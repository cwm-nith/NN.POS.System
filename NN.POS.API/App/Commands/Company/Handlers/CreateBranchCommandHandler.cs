using MediatR;
using NN.POS.API.Core.IRepositories.Company;
using NN.POS.Model.Dtos.Company.Branches;

namespace NN.POS.API.App.Commands.Company.Handlers;

public class CreateBranchCommandHandler(IBranchRepository repository) : IRequestHandler<CreateBranchCommand>
{
    public async Task Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        await repository.CreateAsync(new BranchDto
        {
            CreatedAt = DateTime.UtcNow,
            Address = r.Address,
            CompanyId = r.CompanyId,
            Id = 0,
            IsDeleted = false,
            Location = r.Location,
            Name = r.Name
        }, cancellationToken);
    }
}