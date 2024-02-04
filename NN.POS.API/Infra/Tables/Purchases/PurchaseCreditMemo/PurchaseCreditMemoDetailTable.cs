using NN.POS.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.Purchases.PurchaseCreditMemo;

[Table("purchase_credit_memo_details")]
public class PurchaseCreditMemoDetailTable : BaseTable
{
    [Column("purchase_credit_memo_id")]
    public int PurchaseAPId { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("uom_id")]
    public int UomId { get; set; }

    [Column("local_ccy_id")]
    public int LocalCcyId { get; set; }

    [Column("discount_value", TypeName = "decimal(18,3)")]
    public decimal DiscountValue { get; set; }

    [Column("discount_type")]
    public DiscountType DiscountType { get; set; }

    [Column("qty", TypeName = "decimal(18,3)")]
    public decimal Qty { get; set; }

    [Column("purchase_price", TypeName = "decimal(18,3)")]
    public decimal PurchasePrice { get; set; }

    [Column("total", TypeName = "decimal(18,3)")]
    public decimal Total { get; set; }

    [Column("total_sys", TypeName = "decimal(18,3)")]
    public decimal TotalSys { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    public PurchaseCreditMemoTable? PurchaseCreditMemo { get; set; }
}
