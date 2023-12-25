using MediatR;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.App.Commands.Currencies.Handlers;

public class CreateCurrencyCommandHandler(ICurrencyRepository repository) : IRequestHandler<CreateCurrencyCommand>
{
    public async Task Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {
        await repository.CreateAsync(new CurrencyDto
        {
            CreatedAt = DateTime.UtcNow,
            Id = 0,
            IsDeleted = false,
            Name = request.Dto.Name,
            Symbol = request.Dto.Symbol
        }, cancellationToken);
    }
}