using MediatR;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.App.Commands.Currencies.Handlers;

public class CreateExchangeRateCommandHandler(IExchangeRateRepository repository) : IRequestHandler<CreateExchangeRateCommand>
{
    public async Task Handle(CreateExchangeRateCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        await repository.CreateAsync(new ExchangeRateDto
        {
            CreatedAt = DateTime.UtcNow,
            CcyId = r.CcyId,
            Id = 0,
            IsDeleted = false,
            Rate = r.Rate,
            SetRate = r.SetRate
        }, cancellationToken);
    }
}