using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.Currencies
{
    [Table("exchange_rates")]
    public class ExchangeRateTable : BaseTable
    {
        [Column("ccy_id")]
        public int CcyId { get; set; }

        [Column("rate", TypeName = "decimal(18,7)")]
        public decimal Rate { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("set_rate", TypeName = "decimal(18,7)")]
        public decimal SetRate { get; set; }
    }
}
