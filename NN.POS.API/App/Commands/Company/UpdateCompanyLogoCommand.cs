using MediatR;
using NN.POS.Model.Dtos.Company;

namespace NN.POS.API.App.Commands.Company;

public class UpdateCompanyLogoCommand(int id, UpdateCompanyLogoDto dto) : IRequest
{
    public int Id => id;
    public UpdateCompanyLogoDto Dto => dto;
}