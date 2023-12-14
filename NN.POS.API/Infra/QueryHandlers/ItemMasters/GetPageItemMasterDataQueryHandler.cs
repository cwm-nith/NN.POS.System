using MediatR;
using NN.POS.API.App.Queries.ItemMasters;
using NN.POS.API.Core.IRepositories.ItemMasters;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.ItemMasters;

namespace NN.POS.API.Infra.QueryHandlers.ItemMasters;

public class GetPageItemMasterDataQueryHandler(IItemMasterDataRepository repository) : IRequestHandler<GetPageItemMasterDataQuery, PagedResult<ItemMasterDataDto>>
{
    public async Task<PagedResult<ItemMasterDataDto>> Handle(GetPageItemMasterDataQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}