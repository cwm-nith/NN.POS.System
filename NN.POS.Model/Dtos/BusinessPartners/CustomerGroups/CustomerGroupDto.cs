namespace NN.POS.Model.Dtos.BusinessPartners.CustomerGroups;

public class CustomerGroupDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// value format is percentage %
    /// </summary>
    public decimal Value { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}