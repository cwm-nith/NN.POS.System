using MediatR;
using NN.POS.API.Core.IRepositories;
using NN.POS.Model.Dtos.PaymentTypes;

namespace NN.POS.API.App.Commands.PaymentTypes.Handlers;

public class CreatePaymentTypeCommandHandler(IPaymentTypeRepository repository) : IRequestHandler<CreatePaymentTypeCommand>
{
    public async Task Handle(CreatePaymentTypeCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        await repository.CreateAsync(new PaymentTypeDto
        {
            CreatedAt = DateTime.UtcNow,
            Id = 0,
            IsDeleted = false,
            Name = r.Name
        }, cancellationToken);
    }
}