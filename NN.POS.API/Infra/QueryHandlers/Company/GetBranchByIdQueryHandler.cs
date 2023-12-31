using MediatR;
using NN.POS.API.App.Queries.Company;
using NN.POS.API.Core.IRepositories.Company;
using NN.POS.Model.Dtos.Company.Branches;

namespace NN.POS.API.Infra.QueryHandlers.Company;

public class GetBranchByIdQueryHandler(IBranchRepository repository) : IRequestHandler<GetBranchByIdQuery, BranchDto>
{
    public async Task<BranchDto> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id, cancellationToken);
    }
}