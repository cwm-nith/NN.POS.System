namespace NN.POS.System.API.Core.Exceptions.Users;

public class InvalidCredentialException : BaseException
{
    public override string Code => "invalid_cred";

    public InvalidCredentialException() : base("Username or Password is invalid!")
    {

    }
}