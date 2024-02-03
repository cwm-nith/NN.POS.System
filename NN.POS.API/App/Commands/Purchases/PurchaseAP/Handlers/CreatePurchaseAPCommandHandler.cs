using MediatR;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.Model.Dtos.Purchases.PurchaseAP;
using NN.POS.Model.Enums;

namespace NN.POS.API.App.Commands.Purchases.PurchaseAP.Handlers;

public class CreatePurchaseAPCommandHandler(IPurchaseAPRepository repository) : IRequestHandler<CreatePurchaseAPCommand>
{
    public async Task Handle(CreatePurchaseAPCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        if (r.Type == PurchaseType.PurchaseAP)
        {
            var status = r.Status;
            if (r.SubTotal > (r.AppliedAmount + (r.DiscountType == DiscountType.Flat ? r.DiscountValue : r.SubTotal * r.DiscountValue / 100)))
            {
                status = PurchaseStatus.Close;
            }
            
            var body = new PurchaseAPDto
            {
                AppliedAmount = r.AppliedAmount,
                BalanceDue = r.BalanceDue,
                BalanceDueSys = r.BalanceDueSys,
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
                PurchaseAPDetails = r.PurchaseAPDetails.Where(i => i.Qty > 0).Select(i => new PurchaseAPDetailDto
                {
                    Qty = i.Qty,
                    CreatedAt = DateTime.UtcNow,
                    DiscountType = i.DiscountType,
                    DiscountValue = i.DiscountValue,
                    Id = 0,
                    IsDeleted = i.IsDeleted,
                    ItemId = i.ItemId,
                    LocalCcyId = i.LocalCcyId,
                    PurchaseAPId = 0,
                    PurchasePrice = i.PurchasePrice,
                    Total = i.Total,
                    TotalSys = i.TotalSys,
                    UomId = i.UomId
                }).ToList(),
                PurRate = r.PurRate,
                Remark = r.Remark,
                ReturnAmount = r.ReturnAmount,
                Status = status,
                SubTotal = r.SubTotal,
                SubTotalSys = r.SubTotalSys,
                SupplyId = r.SupplyId,
                SysCcyId = r.SysCcyId,
                TaxRate = r.TaxRate,
                TaxValue = r.TaxValue,
                UserId = request.UserId,
                WarehouseId = r.WarehouseId
            };

            await repository.CreateAsync(body, r.Type, cancellationToken);
        }
    }
}
