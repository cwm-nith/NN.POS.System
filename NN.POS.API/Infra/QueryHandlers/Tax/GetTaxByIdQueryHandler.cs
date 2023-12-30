using MediatR;
using NN.POS.API.App.Queries.Tax;
using NN.POS.API.Core.IRepositories.Tax;
using NN.POS.Model.Dtos.Tax;

namespace NN.POS.API.Infra.QueryHandlers.Tax;

public class GetTaxByIdQueryHandler(ITaxRepository repository) : IRequestHandler<GetTaxByIdQuery, TaxDto>
{
    public async Task<TaxDto> Handle(GetTaxByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id, cancellationToken);
    }
}
