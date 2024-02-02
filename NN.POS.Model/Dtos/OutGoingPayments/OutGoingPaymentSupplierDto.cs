using NN.POS.Model.Enums;

namespace NN.POS.Model.Dtos.OutGoingPayments;
public class OutGoingPaymentSupplierDto : IBaseDto
{
    public int Id { get; set; }
    public int SupplierId { get; set; }
    public int BranchId { get; set; }
    public int WarehouseId { get; set; }
    public int CcyId { get; set; }
    public string InvoiceNo { get; set; } = string.Empty;
    public DocumentInvoicingType DocumentType { get; set; }
    public DateTime PostingDate { get; set; }
    public DateTime Date { get; set; }
    public decimal OverdueDays { get; set; }
    public decimal Total { get; set; }
    public decimal BalanceDue { get; set; }
    public decimal TotalPayment { get; set; }
    public decimal AppliedAmount { get; set; }
    public PurchaseStatus Status { get; set; }
    public decimal DiscountValue { get; set; }
    public DiscountType DiscountType { get; set; }
    public decimal Cash { get; set; }
    public decimal ExchangeRate { get; set; }
    public int SysCcyId { get; set; }
    public int LocalCcyId { get; set; }
    public decimal LocalSetRate { get; set; }
    public DateTime CreatedAt { get; set; }
}
