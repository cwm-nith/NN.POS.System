using MediatR;
using NN.POS.Model.Dtos.Company.Branches;

namespace NN.POS.API.App.Queries.Company;

public class GetBranchByIdQuery(int id) : IRequest<BranchDto>
{
    public int Id => id;
}