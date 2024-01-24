namespace NN.POS.Web.Models;

public class AuthenticateUser
{
    public int UserId { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public List<string> Roles { get; set; } = [];
    public int Nbf { get; set; }
    public int Exp { get; set; }
    public int Iat { get; set; }
    public string? Iss { get; set; }
    public string? Aud { get; set; }
}