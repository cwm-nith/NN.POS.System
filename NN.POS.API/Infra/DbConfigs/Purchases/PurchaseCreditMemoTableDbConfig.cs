using Microsoft.EntityFrameworkCore;
using NN.POS.API.Infra.Tables.Purchases.PurchaseCreditMemo;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.DbConfigs.Purchases;

public static class PurchaseCreditMemoTableDbConfig
{
    public static ModelBuilder PurchaseCreditMemoTableConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PurchaseCreditMemoTable>()
            .HasMany(i => i.PurchaseCreditMemoDetails)
            .WithOne(i => i.PurchaseCreditMemo)
            .HasForeignKey(i => i.PurchaseCreditMemoId);

        modelBuilder.Entity<PurchaseCreditMemoTable>()
            .Property(x => x.Status)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<PurchaseStatus>(false));

        modelBuilder.Entity<PurchaseCreditMemoTable>()
            .Property(x => x.DiscountType)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<DiscountType>(false));

        modelBuilder.Entity<PurchaseCreditMemoDetailTable>()
            .Property(x => x.DiscountType)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<DiscountType>(false));

        return modelBuilder;
    }
}