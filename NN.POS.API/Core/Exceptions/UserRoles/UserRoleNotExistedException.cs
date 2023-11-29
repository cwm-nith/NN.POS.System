namespace NN.POS.API.Core.Exceptions.UserRoles;

public class UserRoleNotExistedException(int userId, int roleId) : BaseException($"User with id \"{userId}\" has not map with role id \"{roleId}\"")
{
    public override string Code => "user_role_not_existed";
}