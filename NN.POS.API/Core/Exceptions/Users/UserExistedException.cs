namespace NN.POS.API.Core.Exceptions.Users;

public class UserExistedException : BaseException
{
    public override string Code => "USER_NOT_FOUND";

    public UserExistedException(int id) : base($"User with id \"{id}\" already existed!")
    {
        
    }

    public UserExistedException(string username) : base($"User with username \"{username}\" already existed!")
    {

    }

    public UserExistedException() : base()
    {

    }
}