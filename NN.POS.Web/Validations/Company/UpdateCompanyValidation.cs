using FluentValidation;
using NN.POS.Model.Dtos.Company;

namespace NN.POS.Web.Validations.Company;

public class UpdateCompanyValidation : BaseValidator<UpdateCompanyDto>
{
    public UpdateCompanyValidation()
    {
        RuleFor(i => i.LocalCcyId)
            .NotEmpty()
            .WithMessage("Please choose Local Currency")
            .Must(i => i > 0)
            .WithMessage("Please choose Local Currency");

        RuleFor(i => i.SysCcyId)
            .NotEmpty()
            .WithMessage("Please choose System Currency")
            .Must(i => i > 0)
            .WithMessage("Please choose System Currency");

        RuleFor(i => i.PriceListId)
            .NotEmpty()
            .WithMessage("Please choose Price List")
            .Must(i => i > 0)
            .WithMessage("Please choose Price List");

        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Please input name");
    }
}