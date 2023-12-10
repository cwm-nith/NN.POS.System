using MediatR;

namespace NN.POS.API.App.Commands.PriceLists;

public class UpdatePriceListCommand : IRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
}