using MediatR;
using NN.POS.Model.Dtos.ItemMasters;

namespace NN.POS.API.App.Commands.ItemMasterData;

public class UpdateItemMasterImageCommand(UpdateItemMasterImageDto dto) : IRequest
{
    public UpdateItemMasterImageDto Dto => dto;
}