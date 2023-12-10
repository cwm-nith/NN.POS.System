namespace NN.POS.Model.Dtos.UnitOfMeasures;

public class UnitOfMeasureDefineDto : IBaseDto
{
    public int Id { get; set; }
    public int BaseUomId { get; set; }

    public int AltUomId { get; set; }

    public int GroupUomId { get; set; }

    public decimal AltQty { get; set; }

    public decimal BaseQty { get; set; }

    public decimal Factor { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
}