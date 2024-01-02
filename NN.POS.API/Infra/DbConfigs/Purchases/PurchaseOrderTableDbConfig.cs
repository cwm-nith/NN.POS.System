using Microsoft.EntityFrameworkCore;
using NN.POS.API.Infra.Tables.Purchases.PurchaseOrders;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.DbConfigs.Purchases;

public static class PurchaseOrderTableDbConfig
{
    public static ModelBuilder PurchaseOrderTableConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PurchaseOrderTable>()
            .HasMany(i => i.PurchaseOrderDetails)
            .WithOne(i => i.PurchaseOrder)
            .HasForeignKey(i => i.PurchaseOrderId);

        modelBuilder.Entity<PurchaseOrderTable>()
            .Property(x => x.Status)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<PurchaseStatus>(false));

        modelBuilder.Entity<PurchaseOrderTable>()
            .Property(x => x.DiscountType)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<DiscountType>(false));

        return modelBuilder;
    }
}