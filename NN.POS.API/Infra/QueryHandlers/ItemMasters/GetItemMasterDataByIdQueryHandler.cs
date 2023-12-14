using MediatR;
using NN.POS.API.App.Queries.ItemMasters;
using NN.POS.API.Core.IRepositories.ItemMasters;
using NN.POS.Model.Dtos.ItemMasters;

namespace NN.POS.API.Infra.QueryHandlers.ItemMasters
{
    public class GetItemMasterDataByIdQueryHandler(IItemMasterDataRepository repository) : IRequestHandler<GetItemMasterDataByIdQuery, ItemMasterDataDto>
    {
        public async Task<ItemMasterDataDto> Handle(GetItemMasterDataByIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
