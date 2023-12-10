using MediatR;

namespace NN.POS.API.App.Commands.PriceLists;

public class DeletePriceListCommand(int id) : IRequest
{
    public int Id => id;
}