using MediatR;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.App.Commands.Currencies;

public class CreateCurrencyCommand(CreateCurrencyDto dto) : IRequest
{
    public CreateCurrencyDto Dto => dto;
}