using MediatR;
using NN.POS.API.Core.IRepositories;

namespace NN.POS.API.App.Commands.PaymentTypes.Handlers;

public class DeletePaymentTypeCommandHandler(IPaymentTypeRepository repository) : IRequestHandler<DeletePaymentTypeCommand>
{
    public async Task Handle(DeletePaymentTypeCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id, cancellationToken);
    }
}