using MediatR;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.App.Commands.Currencies;

public class CreateExchangeRateCommand(CreateExchangeRateDto dto) : IRequest
{
    public CreateExchangeRateDto Dto => dto;
}