using MediatR;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.App.Commands.PriceLists;

public class UpdatePriceListDetailCommand(int id, UpdatePriceListDetailDto dto) : IRequest
{
    public int Id => id;
    public UpdatePriceListDetailDto Dto => dto;
}