namespace NN.POS.System.Model.Dtos.Roles;

public class UserRoleDto : IBaseDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public bool IsInRole { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}