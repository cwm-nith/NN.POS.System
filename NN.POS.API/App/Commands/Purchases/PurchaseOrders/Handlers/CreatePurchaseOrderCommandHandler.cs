using MediatR;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;

namespace NN.POS.API.App.Commands.Purchases.PurchaseOrders.Handlers;

public class CreatePurchaseOrderCommandHandler(IPurchaseOrderRepository repository) : IRequestHandler<CreatePurchaseOrderCommand>
{
    public async Task Handle(CreatePurchaseOrderCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        await repository.CreateAsync(new PurchaseOrderDto
        {
            CreatedAt = DateTime.UtcNow,
            AppliedAmount = r.AppliedAmount,
            BalanceDue = r.BalanceDue,
            BalanceDueSys = r.BalanceDueSys,
            BranchId = r.BranchId,
            DeliveryDate = r.DeliveryDate,
            DiscountRate = r.DiscountRate,
            DiscountType = r.DiscountType,
            DiscountValue = r.DiscountValue,
            DocumentDate = r.DocumentDate,
            DownPayment = r.DownPayment,
            Status = r.Status,
            InvoiceNo = r.InvoiceNo,
            PurchaseOrderDetails = r.PurchaseOrderDetails.Where(i => i.Qty > 0).Select(i => new PurchaseOrderDetailDto
            {
                CreatedAt = DateTime.UtcNow,
                DiscountRate = i.DiscountRate,
                DiscountType = i.DiscountType,
                DiscountValue = i.DiscountValue,
                LocalCcyId = i.LocalCcyId,
                ItemId = i.ItemId,
                PurchasePrice = i.PurchasePrice,
                Qty = i.Qty,
                Total = i.Total,
                TotalSys = i.TotalSys,
                UomId = i.UomId
            }).ToList(),
            PostingDate = r.PostingDate,
            WarehouseId = r.WarehouseId,
            PurCcyId = r.PurCcyId,
            PurRate = r.PurRate,
            Remark = r.Remark,
            ReturnAmount = r.ReturnAmount,
            SubTotal = r.SubTotal,
            SubTotalSys = r.SubTotalSys,
            SupplyId = r.SupplyId,
            UserId = request.UserId,
            TaxRate = r.TaxRate,
            TaxValue = r.TaxValue
        }, cancellationToken);
    }
}