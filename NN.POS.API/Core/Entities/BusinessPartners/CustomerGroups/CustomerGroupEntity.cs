using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Core.Entities.BusinessPartners.CustomerGroups;

public class CustomerGroupEntity : IBaseEntity
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