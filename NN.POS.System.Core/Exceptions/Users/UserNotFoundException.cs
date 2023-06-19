namespace NN.POS.System.Core.Exceptions.Users;

public class UserNotFoundException : BaseException
{
    public override string Code => "USER_NOT_FOUND";

    public UserNotFoundException(Guid id) : base($"User with id \"{id}\" not found!")
    {
        
    }
}