using MediatR;
using NN.POS.API.Core.IRepositories.Currencies;

namespace NN.POS.API.App.Commands.Currencies.Handlers;

public class DeleteCurrencyCommandHandler(ICurrencyRepository repository) : IRequestHandler<DeleteCurrencyCommand>
{
    public async Task Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id, cancellationToken);
    }
}