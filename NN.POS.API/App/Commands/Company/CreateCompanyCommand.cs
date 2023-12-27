using MediatR;
using NN.POS.Model.Dtos.Company;

namespace NN.POS.API.App.Commands.Company;

public class CreateCompanyCommand(CreateCompanyDto dto) : IRequest
{
    public CreateCompanyDto Dto => dto;
}