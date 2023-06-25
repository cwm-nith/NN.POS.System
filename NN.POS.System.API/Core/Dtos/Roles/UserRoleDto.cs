namespace NN.POS.System.API.Core.Dtos.Roles
{
    public class UserRoleDto : IBaseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public bool IsInRole { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UserRoleDto(int id, int userId, int roleId, string name,
            DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            UserId = userId;
            RoleId = roleId;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
