using Microsoft.EntityFrameworkCore;
using NN.POS.API.Infra.Tables.Inventories;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.DbConfigs;

public static class InventoryAuditTableDbConfig
{
    public static ModelBuilder InventoryAuditTableConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InventoryAuditTable>()
            .Property(x => x.Process)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<ItemMasterDataProcess>(false));

        modelBuilder.Entity<InventoryAuditTable>()
            .Property(x => x.TransType)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<DocumentInvoicingType>(false));

        return modelBuilder;
    }
}