using Microsoft.EntityFrameworkCore;
using NN.POS.API.Infra.Tables.OutGoingPayments;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.DbConfigs;

public static class OutGoingPaymentTableDbConfig
{
    public static ModelBuilder OutGoingPaymentTableConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OutGoingPaymentSupplierTable>()
            .Property(x => x.Status)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<PurchaseStatus>(false));

        modelBuilder.Entity<OutGoingPaymentSupplierTable>()
            .Property(x => x.DiscountType)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<DiscountType>(false));

        modelBuilder.Entity<OutGoingPaymentSupplierTable>()
            .Property(x => x.DocumentType)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<DocumentInvoicingType>(false));

        return modelBuilder;
    }
}
