using MediatR;
using NN.POS.Model.Dtos.Tax;

namespace NN.POS.API.App.Queries.Tax;

public class GetTaxByIdQuery(int id) : IRequest<TaxDto>
{
    public int Id => id;
}