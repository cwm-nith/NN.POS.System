using MediatR;
using NN.POS.API.App.Queries.ItemMasters;
using NN.POS.API.Core.Exceptions.ItemMasters;
using NN.POS.API.Core.IRepositories.ItemMasters;
using NN.POS.Model.Dtos.ItemMasters;

namespace NN.POS.API.Infra.QueryHandlers.ItemMasters;

public class GetItemMasterDataUniqueQueryHandler(IItemMasterDataRepository repository) : IRequestHandler<GetItemMasterDataUniqueQuery, ItemMasterDataDto>
{
    public async Task<ItemMasterDataDto> Handle(GetItemMasterDataUniqueQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Q.Barcode) && string.IsNullOrWhiteSpace(request.Q.Code))
        {
            throw new BarcodeOrCodeNeedToHaveOneException();
        }

        if (!string.IsNullOrWhiteSpace(request.Q.Barcode))
        {
            return await repository.GetByBarcodeAsync(request.Q.Barcode, cancellationToken);
        }

        if (!string.IsNullOrWhiteSpace(request.Q.Code))
        {
            return await repository.GetByCodeAsync(request.Q.Code, cancellationToken);
        }

        return default!;
    }
}