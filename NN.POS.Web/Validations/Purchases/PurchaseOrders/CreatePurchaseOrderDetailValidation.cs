using FluentValidation;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;
using System.Text.RegularExpressions;

namespace NN.POS.Web.Validations.Purchases.PurchaseOrders;

public class CreatePurchaseOrderDetailValidation : BaseValidator<CreatePurchaseOrderDetailDto>
{
    public CreatePurchaseOrderDetailValidation()
    {
        RuleFor(i => i.DiscountValue)
        .Must(i =>
            {
                const string pattern1 = "/^[0-9]*$/g";
                var rg1 = new Regex(pattern1);

                const string pattern2 = @"/(\..*){2,}/g";
                var rg2 = new Regex(pattern2);

                return rg1.IsMatch(i.ToString("N3")) && rg2.IsMatch(i.ToString("N3"));
            });
    }
}