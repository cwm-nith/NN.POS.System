using FluentValidation;
using NN.POS.Model.Dtos.Purchases.PurchaseCreditMemo;
using NN.POS.Web.RegexExpression;

namespace NN.POS.Web.Validations.Purchases.PurchaseCreditMemo;

public class CreatePurchaseCreditMemoDetailValidation : BaseValidator<CreatePurchaseCreditMemoDetailDto>
{
    public CreatePurchaseCreditMemoDetailValidation()
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
