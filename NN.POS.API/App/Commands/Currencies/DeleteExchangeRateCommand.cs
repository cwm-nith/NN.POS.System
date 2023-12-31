using MediatR;

namespace NN.POS.API.App.Commands.Currencies;

public class DeleteExchangeRateCommand(int id) : IRequest
{
    public int Id => id;
}