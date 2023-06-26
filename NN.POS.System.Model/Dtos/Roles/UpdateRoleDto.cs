namespace NN.POS.System.Model.Dtos.Roles;

public class UpdateRoleDto : IBaseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}