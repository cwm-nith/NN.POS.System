using System.ComponentModel.DataAnnotations;

namespace NN.POS.Model.Dtos.Roles;

public class CreateRoleDto : IBaseDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
}