namespace NN.POS.System.API.Core.Exceptions.UserRoles;

public class UserRoleAlreadyExistedException : BaseException
{
    public override string Code => "user_role_already_existed";

    public UserRoleAlreadyExistedException(int userId, int roleId)
        : base($"User with id \"{userId}\" already has role with id \"{roleId}\"")
    {

    }
}