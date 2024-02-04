using NN.POS.Model.Dtos.OutGoingPayments;
using NN.POS.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.OutGoingPayments;

[Table("out_going_payment_suppliers")]
public class OutGoingPaymentSupplierTable : BaseTable
{
    [Column("supply_id")]
    public int SupplyId { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("warehouse_id")]
    public int WarehouseId { get; set; }

    [Column("ccy_id")]
    public int CcyId { get; set; }

    [Column("invoice_no"), StringLength(20)]
    public string InvoiceNo { get; set; } = string.Empty;

    [Column("document_type")]
    public DocumentInvoicingType DocumentType { get; set; }

    [Column("posting_date")]
    public DateTime PostingDate { get; set; }

    [Column("date")]
    public DateTime Date { get; set; }

    [Column("overdue_days", TypeName = "demical(18,2)")]
    public decimal OverdueDays { get; set; }

    [Column("total", TypeName = "demical(18,4)")]
    public decimal Total { get; set; }

    [Column("balance_due", TypeName = "demical(18,4)")]
    public decimal BalanceDue { get; set; }

    [Column("total_payment", TypeName = "demical(18,4)")]
    public decimal TotalPayment { get; set; }

    [Column("applied_amount", TypeName = "demical(18,4)")]
    public decimal AppliedAmount { get; set; }

    [Column("status")]
    public PurchaseStatus Status { get; set; }

    [Column("discount_value", TypeName = "demical(18,4)")]
    public decimal DiscountValue { get; set; }

    [Column("discount_type")]
    public DiscountType DiscountType { get; set; }

    [Column("cash", TypeName = "demical(18,4)")]
    public decimal Cash { get; set; }

    [Column("exchange_rate", TypeName = "demical(18,4)")]
    public decimal ExchangeRate { get; set; }

    [Column("sys_ccy_id")]
    public int SysCcyId { get; set; }

    [Column("local_ccy_id")]
    public int LocalCcyId { get; set; }

    [Column("local_set_rate", TypeName = "demical(18,4)")]
    public decimal LocalSetRate { get; set; }
}

public static class OutGoingPaymentSupplierExtensions
{
    public static OutGoingPaymentSupplierDto ToDto(this OutGoingPaymentSupplierTable o) => new()
    {
        AppliedAmount = o.AppliedAmount,
        BalanceDue = o.BalanceDue,
        BranchId = o.BranchId,
        Cash = o.Cash,
        CcyId = o.CcyId,
        CreatedAt = o.CreatedAt,
        Date = o.Date,
        DiscountType = o.DiscountType,
        DiscountValue = o.DiscountValue,
        DocumentType = o.DocumentType,
        ExchangeRate = o.ExchangeRate,
        Id = o.Id,
        InvoiceNo = o.InvoiceNo,
        LocalCcyId = o.LocalCcyId,
        LocalSetRate = o.LocalSetRate,
        OverdueDays = o.OverdueDays,
        PostingDate = o.PostingDate,
        Status = o.Status,
        SupplierId = o.SupplyId,
        SysCcyId = o.SysCcyId,
        Total = o.Total,
        TotalPayment = o.TotalPayment,
        WarehouseId = o.WarehouseId
    };

    public static OutGoingPaymentSupplierTable ToTable(this OutGoingPaymentSupplierDto o) => new()
    {
        AppliedAmount = o.AppliedAmount,
        BalanceDue = o.BalanceDue,
        BranchId = o.BranchId,
        Cash = o.Cash,
        CcyId = o.CcyId,
        CreatedAt = o.CreatedAt,
        Date = o.Date,
        DiscountType = o.DiscountType,
        DiscountValue = o.DiscountValue,
        DocumentType = o.DocumentType,
        ExchangeRate = o.ExchangeRate,
        Id = o.Id,
        InvoiceNo = o.InvoiceNo,
        LocalCcyId = o.LocalCcyId,
        LocalSetRate = o.LocalSetRate,
        OverdueDays = o.OverdueDays,
        PostingDate = o.PostingDate,
        Status = o.Status,
        SupplyId = o.SupplierId,
        SysCcyId = o.SysCcyId,
        Total = o.Total,
        TotalPayment = o.TotalPayment,
        WarehouseId = o.WarehouseId
    };
}