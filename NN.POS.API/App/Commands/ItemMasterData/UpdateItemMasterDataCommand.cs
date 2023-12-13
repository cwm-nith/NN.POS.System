using MediatR;
using NN.POS.Model.Dtos.ItemMasters;

namespace NN.POS.API.App.Commands.ItemMasterData;

public class UpdateItemMasterDataCommand(int id, UpdateItemMasterDataDto dto):IRequest
{
    public int Id => id;
    public UpdateItemMasterDataDto Dto => dto;
}