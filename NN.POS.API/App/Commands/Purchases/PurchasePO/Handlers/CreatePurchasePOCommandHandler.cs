using MediatR;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.Model.Dtos.Purchases.PurchasePO;

namespace NN.POS.API.App.Commands.Purchases.PurchasePO.Handlers;

public class CreatePurchasePOCommandHandler(IPurchasePORepository repository) : IRequestHandler<CreatePurchasePOCommand>
{
    public async Task Handle(CreatePurchasePOCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        var userId = request.UserId;
        await repository.CreateAsync(new PurchasePODto
        {
            AppliedAmount = r.AppliedAmount,
            BalanceDue = r.BalanceDue,
            BalanceDueSys = r.BalanceDueSys,
            BranchId = r.BranchId,
            CreatedAt = DateTime.UtcNow,
            DiscountType = r.DiscountType,
            DiscountValue = r.DiscountValue,
            DocumentDate = r.DocumentDate,
            DownPayment = r.DownPayment,
            DueDate = r.DueDate,
            Id = 0,
            InvoiceNo = r.InvoiceNo,
            LocalCcyId = r.LocalCcyId,
            LocalSetRate = r.LocalSetRate,
            PostingDate = r.PostingDate,
            PurCcyId = r.PurCcyId,
            PurchasePODetails = r.PurchasePODetail.Select(i => new PurchasePODetailDto
            {
                CreatedAt = DateTime.UtcNow,
                DiscountType = i.DiscountType,
                DiscountValue = i.DiscountValue,
                Id = 0,
                IsDeleted = i.IsDeleted,
                ItemId = i.ItemId,
                LocalCcyId = i.LocalCcyId,
                PurchasePOId = i.PurchasePOId,
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
            UserId = userId,
            WarehouseId = r.WarehouseId
        }, cancellationToken);
    }
}
