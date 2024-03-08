using FluentValidation;
using NN.POS.Model.Dtos.Purchases.PurchaseCreditMemo;

namespace NN.POS.Web.Validations.Purchases.PurchaseCreditMemo;

public class CreatePurchaseCreditMemoValidation : BaseValidator<CreatePurchaseCreditMemoDto>
{
    public CreatePurchaseCreditMemoValidation()
    {
        RuleFor(i => i.SupplyId)
            .GreaterThan(0)
            .WithMessage("Please choose suppliers");

        RuleFor(i => i.WarehouseId)
            .GreaterThan(0)
            .WithMessage("Please choose warehouse");

        RuleFor(i => i.PurCcyId)
            .GreaterThan(0)
            .WithMessage("Please choose Purchase Currency");

        RuleForEach(i => i.PurchaseCreditMemoDetails)
            .SetValidator(new CreatePurchaseCreditMemoDetailValidation());
    }
}
