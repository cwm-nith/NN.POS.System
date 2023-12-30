using MediatR;
using NN.POS.Model.Dtos.Tax;

namespace NN.POS.API.App.Commands.Tax;

public class CreateTaxCommand(CreateTaxDto dto) : IRequest
{
    public CreateTaxDto Dto => dto;
}