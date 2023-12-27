using MediatR;
using NN.POS.Model.Dtos.Company;

namespace NN.POS.API.App.Commands.Company;

public class UpdateCompanyCommand(int id, UpdateCompanyDto dto) : IRequest
{
    public int Id => id;
    public UpdateCompanyDto Dto => dto;
}