using FluentValidation;
using NN.POS.Model.Dtos.Purchases.PurchasePO;

namespace NN.POS.Web.Validations.Purchases.PurchasePO;

public class CreatePurchasePOValidation : BaseValidator<CreatePurchasePODto>
{
    public CreatePurchasePOValidation()
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

        RuleForEach(i => i.PurchasePODetails)
            .SetValidator(new CreatePurchasePODetailValidation());
    }
}