namespace NN.POS.System.API.Core.Dtos.Roles;

public class UpdateRoleDto : IBaseDto
{
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
}