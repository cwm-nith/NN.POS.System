using System.ComponentModel.DataAnnotations;

namespace NN.POS.Model.Dtos.Users;

public class CreateUserDto : CreateUserDtoBase, IBaseDto
{
}

public class CreateUserDtoBase
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


public class CreateUserBfDto : CreateUserDtoBase, IBaseDto
{
    public string ConfirmPassword { get; set; } = string.Empty;
}