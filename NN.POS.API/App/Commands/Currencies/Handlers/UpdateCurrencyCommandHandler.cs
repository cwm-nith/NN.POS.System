using MediatR;
using NN.POS.API.Core.IRepositories.Currencies;

namespace NN.POS.API.App.Commands.Currencies.Handlers;

public class UpdateCurrencyCommandHandler(ICurrencyRepository repository) : IRequestHandler<UpdateCurrencyCommand>
{
    public async Task Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        var ccy = await repository.GetByIdAsync(request.Id, cancellationToken);

        ccy.Name = r.Name ?? ccy.Name;
        ccy.Symbol = r.Symbol ?? ccy.Symbol;

        await repository.UpdateAsync(ccy, cancellationToken);
    }
}