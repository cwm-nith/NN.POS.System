using MediatR;
using NN.POS.System.API.Core.IRepositories.BusinessPartners;

namespace NN.POS.System.API.App.Commands.BusinessPartners.Handlers;

public class DeleteBusinessPartnerCommandHandler : IRequestHandler<DeleteBusinessPartnerCommand, bool>
{
    private readonly IBusinessPartnerRepository _businessPartnerRepository;

    public DeleteBusinessPartnerCommandHandler(IBusinessPartnerRepository businessPartnerRepository)
    {
        _businessPartnerRepository = businessPartnerRepository;
    }

    public Task<bool> Handle(DeleteBusinessPartnerCommand request, CancellationToken cancellationToken)
    {
        return _businessPartnerRepository.DeleteAsync(request.Id, cancellationToken);
    }
}