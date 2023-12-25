using MediatR;

namespace NN.POS.API.App.Commands.Currencies;

public class DeleteCurrencyCommand(int id) : IRequest
{
    public int Id => id;
}