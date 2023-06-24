namespace NN.POS.System.API.Core.Exceptions.Roles;

public class RoleNotFoundException : BaseException
{
    public override string Code => "role_not_found";

    public RoleNotFoundException(string name): base($"Role with name \"{name}\" is not found!")
    {
        
    }

    public RoleNotFoundException(int id) : base($"Role with Id \"{id}\" is not found!")
    {

    }
}