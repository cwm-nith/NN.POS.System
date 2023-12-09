namespace NN.POS.Model.Dtos.UnitOfMeasures;

public class UnitOfMeasureDto : IBaseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
}