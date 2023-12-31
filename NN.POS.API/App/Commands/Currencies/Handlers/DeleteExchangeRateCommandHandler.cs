using MediatR;
using NN.POS.API.Core.IRepositories.Currencies;

namespace NN.POS.API.App.Commands.Currencies.Handlers;

public class DeleteExchangeRateCommandHandler(IExchangeRateRepository repository) : IRequestHandler<DeleteExchangeRateCommand>
{
    public async Task Handle(DeleteExchangeRateCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id, cancellationToken);
    }
}