using Microsoft.EntityFrameworkCore;
using NN.POS.API.Infra.Tables.BusinessPartners;
using NN.POS.Model.Enums;
using static NN.POS.Model.Enums.BusinessPartnerEnum;

namespace NN.POS.API.Infra.DbConfigs;

public static class BusinessPartnerTableConfig
{
    public static ModelBuilder BusinessPartnerConfig(this ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<BusinessPartnerTable>();
        builder
            .Property(x => x.BusinessType)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<BusinessType>(false));

        builder
            .Property(x => x.ContactType)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<ContactType>(false));

        return modelBuilder;
    }
}