using MediatR;
using NN.POS.Model.Dtos.BusinessPartners;

namespace NN.POS.API.App.Queries.BusinessPartners;

public class GetBusinessPartnerByIdQuery : IRequest<BusinessPartnerDto>
{
    public int Id { get; set; }

    public GetBusinessPartnerByIdQuery(int id)
    {
        Id = id;
    }
}