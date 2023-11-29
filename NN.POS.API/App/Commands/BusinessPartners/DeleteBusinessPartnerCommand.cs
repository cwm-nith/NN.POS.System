using MediatR;

namespace NN.POS.API.App.Commands.BusinessPartners;

public class DeleteBusinessPartnerCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteBusinessPartnerCommand(int id)
    {
        Id = id;
    }
}