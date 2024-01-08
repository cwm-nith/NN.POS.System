using MediatR;
using NN.POS.Model.Dtos.ItemMasters;

namespace NN.POS.API.App.Commands.ItemMasterData;

public class CreateItemMasterDataCommand(int userId, CreateItemMasterDataDto dto) : IRequest
{
    public int UserId => userId;
    public CreateItemMasterDataDto Dto => dto;
}