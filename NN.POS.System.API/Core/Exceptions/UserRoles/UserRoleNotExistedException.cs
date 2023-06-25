namespace NN.POS.System.API.Core.Exceptions.UserRoles;

public class UserRoleNotExistedException : BaseException
{
    public override string Code => "user_role_not_existed";

    public UserRoleNotExistedException(int userId, int roleId)
        : base($"User with id \"{userId}\" has not map with role id \"{roleId}\"")
    {

    }
}