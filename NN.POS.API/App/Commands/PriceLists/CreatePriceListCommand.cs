using MediatR;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.App.Commands.PriceLists;

public class CreatePriceListCommand(CreatePriceListDto dto) : IRequest
{
    public CreatePriceListDto Dto => dto;
}