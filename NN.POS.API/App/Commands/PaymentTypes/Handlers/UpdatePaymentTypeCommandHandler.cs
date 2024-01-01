using MediatR;
using NN.POS.API.Core.IRepositories;

namespace NN.POS.API.App.Commands.PaymentTypes.Handlers;

public class UpdatePaymentTypeCommandHandler(IPaymentTypeRepository repository) : IRequestHandler<UpdatePaymentTypeCommand>
{
    public async Task Handle(UpdatePaymentTypeCommand request, CancellationToken cancellationToken)
    {
        var pmt = await repository.GetByIdAsync(request.Id, cancellationToken);
        pmt.Name = request.Dto.Name;
        await repository.UpdateAsync(pmt, cancellationToken);
    }
}