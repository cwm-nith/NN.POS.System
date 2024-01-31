using MediatR;

namespace NN.POS.API.App.Commands.Purchases.PurchaseAP.Handlers;

public class CreatePurchaseAPCommandHandler : IRequestHandler<CreatePurchaseAPCommand>
{
    public Task Handle(CreatePurchaseAPCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
