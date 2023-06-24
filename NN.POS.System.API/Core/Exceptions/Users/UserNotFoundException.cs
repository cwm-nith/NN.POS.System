namespace NN.POS.System.API.Core.Exceptions.Users;

public class UserNotFoundException : BaseException
{
    public override string Code => "USER_NOT_FOUND";

    public UserNotFoundException(int id) : base($"User with id \"{id}\" not found!")
    {
        
    }

    public UserNotFoundException(string name) : base($"User with name \"{name}\" not found!")
    {

    }

    public UserNotFoundException() : base()
    {

    }
}