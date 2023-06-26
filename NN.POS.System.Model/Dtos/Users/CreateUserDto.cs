using System.ComponentModel.DataAnnotations;

namespace NN.POS.System.Model.Dtos.Users;

public class CreateUserDto : IBaseDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
}