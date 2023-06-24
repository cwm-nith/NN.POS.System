namespace NN.POS.System.API.Core.Exceptions.Users;

public class UserNotFoundException : BaseException
{
    public override string Code => "USER_NOT_FOUND";

    public UserNotFoundException(int id) : base($"User with id \"{id}\" not found!")
    {
        
    }

    public UserNotFoundException(string username, bool isEmail = false) : base(!isEmail
        ? $"User with username \"{username}\" not found!"
        : $"User with email \"{username}\" not found!")
    {

    }

    public UserNotFoundException() : base()
    {

    }
}