using NN.POS.Model.Dtos.Purchases.PurchaseOrders;

namespace NN.POS.API.Infra.Tables.Purchases.PurchaseOrders;

public static class PurchaseOrderExtensions
{
    public static PurchaseOrderDto ToDto(
        this PurchaseOrderTable p,
        string? branchName = null,
        string? sysCcyName = null,
        string? localCcyName = null,
        string? wsName = null,
        string? purCcyName = null,
        string? supplyName = null,
        string? userName = null
        ) => new()
        {
            CreatedAt = p.CreatedAt,
            AppliedAmount = p.AppliedAmount,
            BalanceDue = p.BalanceDue,
            BalanceDueSys = p.BalanceDueSys,
            BranchId = p.BranchId,
            BranchName = branchName,
            DeliveryDate = p.DeliveryDate,
            DiscountRate = p.DiscountRate,
            DiscountType = p.DiscountType,
            DiscountValue = p.DiscountValue,
            DocumentDate = p.DocumentDate,
            DownPayment = p.DownPayment,
            Id = p.Id,
            SysCcyId = p.SysCcyId,
            SysCcyName = sysCcyName,
            LocalCcyId = p.LocalCcyId,
            LocalCcyName = localCcyName,
            WarehouseId = p.WarehouseId,
            WarehouseName = wsName,
            Status = p.Status,
            PurchaseOrderDetails = p.PurchaseOrderDetails.Select(i => i.ToDto()).ToList(),
            InvoiceNo = p.InvoiceNo,
            LocalSetRate = p.LocalSetRate,
            PostingDate = p.PostingDate,
            PurCcyId = p.PurCcyId,
            PurCcyName = purCcyName,
            PurRate = p.PurRate,
            Remark = p.Remark,
            ReturnAmount = p.ReturnAmount,
            SubTotal = p.SubTotal,
            SubTotalSys = p.SubTotalSys,
            SupplyId = p.SupplyId,
            SupplyName = supplyName,
            TaxRate = p.TaxRate,
            TaxValue = p.TaxValue,
            UserId = p.UserId,
            UserName = userName
        };

    public static PurchaseOrderTable ToTable(this PurchaseOrderDto p) => new()
    {
        CreatedAt = p.CreatedAt,
        AppliedAmount = p.AppliedAmount,
        BalanceDue = p.BalanceDue,
        BalanceDueSys = p.BalanceDueSys,
        BranchId = p.BranchId,
        DeliveryDate = p.DeliveryDate,
        DiscountRate = p.DiscountRate,
        DiscountType = p.DiscountType,
        DiscountValue = p.DiscountValue,
        DocumentDate = p.DocumentDate,
        DownPayment = p.DownPayment,
        Id = p.Id,
        SysCcyId = p.SysCcyId,
        LocalCcyId = p.LocalCcyId,
        WarehouseId = p.WarehouseId,
        Status = p.Status,
        PurchaseOrderDetails = p.PurchaseOrderDetails.Select(i => i.ToTable()).ToList(),
        InvoiceNo = p.InvoiceNo,
        LocalSetRate = p.LocalSetRate,
        PostingDate = p.PostingDate,
        PurCcyId = p.PurCcyId,
        PurRate = p.PurRate,
        Remark = p.Remark,
        ReturnAmount = p.ReturnAmount,
        SubTotal = p.SubTotal,
        SubTotalSys = p.SubTotalSys,
        SupplyId = p.SupplyId,
        TaxRate = p.TaxRate,
        TaxValue = p.TaxValue,
        UserId = p.UserId
    };
}