namespace NN.POS.API.Core.Exceptions.Users;

public class InvalidCredentialException() : BaseException("Username or Password is invalid!", statusCode: 401)
{
    public override string Code => "invalid_cred";
}