using NN.POS.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.OutGoingPayments;

[Table("out_going_payment_suppliers")]
public class OutGoingPaymentSupplierTable : BaseTable
{
    [Column("supplier_id")]
    public int SupplierId { get; set; }

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
    public int LocalCcyID { get; set; }

    [Column("local_set_rate", TypeName = "demical(18,4)")]
    public decimal LocalSetRate { get; set; }
}
