using FluentValidation;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;

namespace NN.POS.Web.Validations.Purchases.PurchaseOrders;

public class CreatePurchaseOrderValidation : BaseValidator<CreatePurchaseOrderDto>
{
    public CreatePurchaseOrderValidation()
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
    }
}