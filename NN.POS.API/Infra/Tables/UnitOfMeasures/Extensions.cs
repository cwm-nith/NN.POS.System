using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Infra.Tables.UnitOfMeasures;

public static class Extensions
{
    public static UnitOfMeasureDto ToDto(this UnitOfMeasureTable u) => new()
    {
        CreatedAt = u.CreatedAt,
        Id = u.Id,
        IsDeleted = u.IsDeleted,
        Name = u.Name
    };

    public static UnitOfMeasureTable ToTable(this UnitOfMeasureDto u) => new()
    {
        CreatedAt = u.CreatedAt,
        Id = u.Id,
        IsDeleted = u.IsDeleted,
        Name = u.Name
    };
}