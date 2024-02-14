using MediatR;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.Model.Dtos.Purchases.PurchaseCreditMemo;

namespace NN.POS.API.App.Commands.Purchases.PurchaseCreditMemo.Handlers;

public class CreatePurchaseCreditMemoCommandHandler(IPurchaseCreditMemoRepository repository) : IRequestHandler<CreatePurchaseCreditMemoCommand, object>
{
    public async Task<object> Handle(CreatePurchaseCreditMemoCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        var dto = new PurchaseCreditMemoDto
        {
            AppliedAmount = r.AppliedAmount,
            BalanceDue = r.BalanceDue,
            BalanceDueSys = r.BalanceDueSys,
            BaseOn = r.BaseOn,
            BaseOnId = r.BaseOnId,
            BranchId = r.BranchId,
            CopyFromId = r.CopyFromId,
            CreatedAt = DateTime.UtcNow,
            DiscountType = r.DiscountType,
            DiscountValue = r.DiscountValue,
            DocumentDate = r.DocumentDate ?? DateTime.UtcNow,
            DownPayment = r.DownPayment,
            DueDate = r.DueDate ?? DateTime.UtcNow,
            Id = 0,
            InvoiceNo = r.InvoiceNo,
            LocalCcyId = r.LocalCcyId,
            LocalSetRate = r.LocalSetRate,
            PostingDate = r.PostingDate ?? DateTime.UtcNow,
            PurCcyId = r.PurCcyId,
            PurchaseCreditMemoDetails = r.PurchaseCreditMemoDetails.Select(i => new PurchaseCreditMemoDetailDto
            {
                CopyFromId = i.CopyFromId,
                CreatedAt = DateTime.UtcNow,
                DiscountType = i.DiscountType,
                DiscountValue = i.DiscountValue,
                IsDeleted = false,
                ItemId = i.ItemId,
                LocalCcyId = i.LocalCcyId,
                PurchasePrice = i.PurchasePrice,
                Qty = i.Qty,
                Total = i.Total,
                TotalSys = i.TotalSys,
                UomId = i.UomId
            }).ToList(),
            PurRate = r.PurRate,
            Remark = r.Remark,
            ReturnAmount = r.ReturnAmount,
            Status = r.Status,
            SubTotal = r.SubTotal,
            SubTotalSys = r.SubTotalSys,
            SupplyId = r.SupplyId,
            SysCcyId = r.SysCcyId,
            TaxRate = r.TaxRate,
            TaxValue = r.TaxValue,
            UserId = request.UserId,
            WarehouseId = r.WarehouseId
        };

        await repository.CreateAsync(dto, request.PurchaseType, cancellationToken);
        return null!;
    }
}
