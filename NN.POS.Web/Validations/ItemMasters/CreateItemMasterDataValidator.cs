using FluentValidation;
using NN.POS.Model.Dtos.ItemMasters;
using NN.POS.Model.Enums;

namespace NN.POS.Web.Validations.ItemMasters;

public class CreateItemMasterDataValidator : BaseValidator<CreateItemMasterDataDto>
{
    public CreateItemMasterDataValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty!");

        RuleFor(i => i.Code)
            .NotEmpty()
            .WithMessage("Code cannot be empty!");

        RuleFor(i => i.Barcode)
            .NotEmpty()
            .WithMessage("Barcode cannot be empty!");

        RuleFor(i => i.PriceListId)
            .Must(i => i > 0)
            .WithMessage("Please choose price list!");

        RuleFor(i => i.BaseUomId)
            .Must(i => i > 0)
            .WithMessage("Please choose Unit of measure (Uom)!");

        RuleFor(i => i.Process)
            .NotEmpty()
            .WithMessage("Process cannot be empty!")
            .Must(i => i != ItemMasterDataProcess.None)
            .WithMessage("Please select Process");

        RuleFor(i => i.Type)
            .NotEmpty()
            .WithMessage("Type cannot be empty!")
            .Must(i => i != ItemMasterDataType.None)
            .WithMessage("Please select Type");

        RuleFor(i => i.UomGroupId)
            .Must(i => i > 0)
            .WithMessage("Please choose Unit of measure Group (UomG)!");

        RuleFor(i => i.WarehouseId)
            .Must(i => i > 0)
            .WithMessage("Please choose warehouse!");
    }
}