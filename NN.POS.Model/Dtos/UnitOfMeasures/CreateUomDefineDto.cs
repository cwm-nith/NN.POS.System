namespace NN.POS.Model.Dtos.UnitOfMeasures;

public class CreateUomDefineDto : IBaseDto
{
    public int BaseUomId { get; set; }

    public int AltUomId { get; set; }

    public int GroupUomId { get; set; }

    public decimal AltQty { get; set; }

    public decimal BaseQty { get; set; }

    public decimal Factor { get; set; }
}