namespace NN.POS.API.Core.Exceptions.UserRoles;

public class UserRoleAlreadyExistedException(int userId, int roleId) : BaseException($"User with id \"{userId}\" already has role with id \"{roleId}\"")
{
    public override string Code => "user_role_already_existed";
}