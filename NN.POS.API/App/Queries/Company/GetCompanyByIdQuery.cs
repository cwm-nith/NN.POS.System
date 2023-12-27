using MediatR;
using NN.POS.Model.Dtos.Company;

namespace NN.POS.API.App.Queries.Company;

public class GetCompanyByIdQuery(int id) : IRequest<CompanyDto>
{
    public int Id => id;
}