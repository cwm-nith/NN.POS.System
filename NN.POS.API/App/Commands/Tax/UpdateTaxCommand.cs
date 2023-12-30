using MediatR;
using NN.POS.Model.Dtos.Tax;

namespace NN.POS.API.App.Commands.Tax;

public class UpdateTaxCommand(int id, CreateTaxDto dto) : IRequest
{
    public int Id => id;
    public CreateTaxDto Dto => dto;
}