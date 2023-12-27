using MediatR;
using NN.POS.Model.Dtos.Company.Branches;

namespace NN.POS.API.App.Commands.Company;

public class UpdateBranchCommand(int id, CreateBranchDto dto): IRequest
{
    public int Id => id;
    public CreateBranchDto Dto => dto;
}