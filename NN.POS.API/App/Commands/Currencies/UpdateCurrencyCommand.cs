using MediatR;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.App.Commands.Currencies;

public class UpdateCurrencyCommand(int id, CreateCurrencyDto dto) : IRequest
{
    public int Id => id;
    public CreateCurrencyDto Dto => dto;
}