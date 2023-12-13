using Microsoft.EntityFrameworkCore;
using NN.POS.API.Infra.Tables.ItemMasters;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.DbConfigs;

public static class ItemMasterDataTableConfig
{
    public static ModelBuilder ItemMasterDataTableDbConfig(this ModelBuilder builder)
    {
        builder.Entity<ItemMasterDataTable>()
            .Property(x => x.Process)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<ItemMasterDataProcess>(false));

        builder.Entity<ItemMasterDataTable>()
            .Property(x => x.Type)
            .HasColumnType("varchar")
            .HasMaxLength(32)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<ItemMasterDataType>(false));

        return builder;
    }
}