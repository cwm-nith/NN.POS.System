using MediatR;
using NN.POS.API.App.Queries.Tax;
using NN.POS.API.Core.IRepositories.Tax;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Tax;

namespace NN.POS.API.Infra.QueryHandlers.Tax;

public class GetTaxPageQueryHandler(ITaxRepository repository) : IRequestHandler<GetTaxPageQuery, PagedResult<TaxDto>>
{
    public async Task<PagedResult<TaxDto>> Handle(GetTaxPageQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}