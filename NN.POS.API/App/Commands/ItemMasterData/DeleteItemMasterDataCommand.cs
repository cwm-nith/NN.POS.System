using MediatR;

namespace NN.POS.API.App.Commands.ItemMasterData;

public class DeleteItemMasterDataCommand(int id) : IRequest
{
    public int Id => id;
}