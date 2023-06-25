namespace NN.POS.System.API.Core.Exceptions.UserRoles;

public class UserRoleNotFoundException : BaseException
{
    public override string Code => "user_role_not_exist";
}