using MediatR;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.App.Commands.PriceLists.Handlers;

public class CreatePriceListCommandHandler(IPriceListRepository repository) : IRequestHandler<CreatePriceListCommand>
{
    public async Task Handle(CreatePriceListCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        await repository.CreateAsync(new PriceListDto
        {
            CcyId = r.CcyId,
            CreatedAt = DateTime.UtcNow,
            Id = 0,
            IsDeleted = false,
            Name = r.Name
        }, cancellationToken);
    }
}