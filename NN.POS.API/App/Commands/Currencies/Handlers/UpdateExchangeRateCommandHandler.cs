using MediatR;
using NN.POS.API.Core.IRepositories.Currencies;

namespace NN.POS.API.App.Commands.Currencies.Handlers;

public class UpdateExchangeRateCommandHandler(IExchangeRateRepository repository) : IRequestHandler<UpdateExchangeRateCommand>
{
    public async Task Handle(UpdateExchangeRateCommand request, CancellationToken cancellationToken)
    {
        var exRate = await repository.GetByIdAsync(request.Id, cancellationToken);
        var r = request.Dto;
        exRate.CcyId = r.CcyId;
        exRate.Rate = r.Rate;
        exRate.SetRate = r.SetRate;

        await repository.UpdateAsync(exRate, cancellationToken);
    }
}