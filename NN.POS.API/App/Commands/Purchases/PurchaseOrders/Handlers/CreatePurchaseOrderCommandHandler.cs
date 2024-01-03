using MediatR;
using NN.POS.API.Core.IRepositories.Purchases;

namespace NN.POS.API.App.Commands.Purchases.PurchaseOrders.Handlers;

public class CreatePurchaseOrderCommandHandler(IPurchaseOrderRepository repository) : IRequestHandler<CreatePurchaseOrderCommand>
{
    public async Task Handle(CreatePurchaseOrderCommand request, CancellationToken cancellationToken)
    {
        
    }
}