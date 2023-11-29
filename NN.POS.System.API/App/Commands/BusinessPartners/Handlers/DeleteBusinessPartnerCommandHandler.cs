using MediatR;
using NN.POS.System.API.Core.IRepositories.BusinessPartners;

namespace NN.POS.System.API.App.Commands.BusinessPartners.Handlers;

public class DeleteBusinessPartnerCommandHandler(IBusinessPartnerRepository businessPartnerRepository) : IRequestHandler<DeleteBusinessPartnerCommand, bool>
{
    public async Task<bool> Handle(DeleteBusinessPartnerCommand request, CancellationToken cancellationToken)
    {
        return await businessPartnerRepository.DeleteAsync(request.Id, cancellationToken);
    }
}