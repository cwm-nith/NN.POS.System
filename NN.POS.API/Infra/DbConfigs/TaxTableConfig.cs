using Microsoft.EntityFrameworkCore;
using NN.POS.API.Infra.Tables.ItemMasters;
using NN.POS.API.Infra.Tables.Tax;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.DbConfigs
{
    public static class TaxTableConfig
    {
        public static ModelBuilder TaxTableDbConfig(this ModelBuilder builder)
        {
            builder.Entity<TaxTable>()
                .Property(x => x.Type)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .HasConversion(
                    v => v.ToEnumString(),
                    v => v.ToEnum<TaxType>(false));
            return builder;
        }
    }
}
