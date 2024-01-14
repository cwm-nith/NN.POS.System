using Microsoft.EntityFrameworkCore;
using NN.POS.API.Infra.Tables;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.DbConfigs;

public static class DocumentInvoicingDbConfig
{
    public static ModelBuilder DocumentInvoicingTableConfig(this ModelBuilder builder)
    {
        builder.Entity<DocumentInvoicingTable>()
            .Property(x => x.Type)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<DocumentInvoicingType>(false));

        return builder;
    }
}