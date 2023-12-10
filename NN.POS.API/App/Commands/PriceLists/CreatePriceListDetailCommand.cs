using MediatR;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.App.Commands.PriceLists
{
    public class CreatePriceListDetailCommand(List<CreatePriceListDetailDto> dto) : IRequest
    {
        public List<CreatePriceListDetailDto> Dto => dto;
    }
}
