using FluentValidation;
using NN.POS.Model.Dtos.Purchases.PurchaseAP;
using NN.POS.Web.Validations.Purchases.PurchasePO;

namespace NN.POS.Web.Validations.Purchases.PurchaseAP;

public class CreatePurchaseAPValidation : BaseValidator<CreatePurchaseAPDto>
{
    public CreatePurchaseAPValidation()
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

        RuleForEach(i => i.PurchaseAPDetails)
            .SetValidator(new CreatePurchaseAPDetailValidation());
    }
}