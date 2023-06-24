namespace NN.POS.System.API.Core.Entities.Roles;

public class RoleEntity : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public RoleEntity(string name, DateTime createdAt, DateTime updatedAt)
    {
        Name = name;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}