using System.ComponentModel.DataAnnotations;

namespace NN.POS.System.API.Core.Dtos.Roles;

public class CreateRoleDto : IBaseDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
}