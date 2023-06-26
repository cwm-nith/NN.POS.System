using MediatR;
using NN.POS.System.Model.Dtos.BusinessPartners;

namespace NN.POS.System.API.App.Queries.BusinessPartners;

public class GetBusinessPartnerByIdQuery : IRequest<BusinessPartnerDto>
{
    public int Id { get; set; }

    public GetBusinessPartnerByIdQuery(int id)
    {
        Id = id;
    }
}