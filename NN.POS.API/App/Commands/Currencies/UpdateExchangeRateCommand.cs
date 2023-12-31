using MediatR;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.App.Commands.Currencies;

public class UpdateExchangeRateCommand(int id, CreateExchangeRateDto dto) : IRequest
{
    public int Id => id;
    public CreateExchangeRateDto Dto => dto;
}