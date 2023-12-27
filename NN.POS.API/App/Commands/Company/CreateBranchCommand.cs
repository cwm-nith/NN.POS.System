using MediatR;
using NN.POS.Model.Dtos.Company.Branches;

namespace NN.POS.API.App.Commands.Company;

public class CreateBranchCommand(CreateBranchDto dto) : IRequest
{
    public CreateBranchDto Dto => dto;
}