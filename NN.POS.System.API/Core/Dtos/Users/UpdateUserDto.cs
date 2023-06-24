namespace NN.POS.System.API.Core.Dtos.Users;

public class UpdateUserDto : IBaseDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }

}