using MediatR;
using NN.POS.API.Core.IRepositories.Tax;

namespace NN.POS.API.App.Commands.Tax.Handlers;

public class UpdateTaxCommandHandler(ITaxRepository repository) : IRequestHandler<UpdateTaxCommand>
{
    public async Task Handle(UpdateTaxCommand request, CancellationToken cancellationToken)
    {
        var tax = await repository.GetByIdAsync(request.Id, cancellationToken);

        var r = request.Dto;

        tax.Name = r.Name;
        tax.Type = r.Type;
        tax.EffectiveDate = r.EffectiveDate;
        tax.Rate = r.Rate;

        await repository.UpdateAsync(tax, cancellationToken);
    }
}