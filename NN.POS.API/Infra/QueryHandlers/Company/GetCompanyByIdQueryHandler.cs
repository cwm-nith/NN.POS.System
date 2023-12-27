using MediatR;
using NN.POS.API.App.Queries.Company;
using NN.POS.API.Core.IRepositories.Company;
using NN.POS.Model.Dtos.Company;

namespace NN.POS.API.Infra.QueryHandlers.Company;

public class GetCompanyByIdQueryHandler(ICompanyRepository repository) : IRequestHandler<GetCompanyByIdQuery, CompanyDto>
{
    public async Task<CompanyDto> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id, cancellationToken);
    }
}