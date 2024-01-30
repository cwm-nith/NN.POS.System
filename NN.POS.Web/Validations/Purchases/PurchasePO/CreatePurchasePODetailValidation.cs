using FluentValidation;
using NN.POS.Model.Dtos.Purchases.PurchasePO;
using NN.POS.Web.RegexExpression;

namespace NN.POS.Web.Validations.Purchases.PurchasePO;

public class CreatePurchasePODetailValidation : BaseValidator<CreatePurchasePODetailDto>
{
    public CreatePurchasePODetailValidation()
    {
        RuleFor(i => i.DiscountValue)
        .Must(i =>
        {
            var rg1 = RegexExpressionHelper.NumberOnlyRegex();

            var rg2 = RegexExpressionHelper.ContainOnlyOneDotRegex();

            return rg1.IsMatch(i.ToString("N3")) && rg2.IsMatch(i.ToString("N3"));
        });
    }
}