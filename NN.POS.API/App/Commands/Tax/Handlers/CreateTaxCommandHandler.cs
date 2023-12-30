using MediatR;
using NN.POS.API.Core.IRepositories.Tax;
using NN.POS.Model.Dtos.Tax;

namespace NN.POS.API.App.Commands.Tax.Handlers;

public class CreateTaxCommandHandler(ITaxRepository repository) : IRequestHandler<CreateTaxCommand>
{
    public async Task Handle(CreateTaxCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        await repository.CreateAsync(new TaxDto
        {
            Name = r.Name,
            CreatedAt = DateTime.UtcNow,
            EffectiveDate = r.EffectiveDate,
            Id = 0,
            IsDeleted = false,
            Type = r.Type,
            Rate = r.Rate
        }, cancellationToken);
    }
}