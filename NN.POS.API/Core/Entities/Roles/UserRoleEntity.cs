namespace NN.POS.API.Core.Entities.Roles;

public class UserRoleEntity:IBaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }

    public UserRoleEntity(int id, int userId, int roleId)
    {
        Id = id;
        UserId = userId;
        RoleId = roleId;
    }
}