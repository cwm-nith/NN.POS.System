using Microsoft.EntityFrameworkCore;
using NN.POS.System.API.Infra.Tables.BusinessPartners;
using NN.POS.System.API.Infra.Tables.Roles;
using NN.POS.System.API.Infra.Tables.User;

namespace NN.POS.System.API.Infra.Tables;

public class DataDbContext(DbContextOptions<DataDbContext> options) : DbContext(options)
{
    public DbSet<UserTable>? Users { get; set; }
    public DbSet<RoleTable>? Roles { get; set; }
    public DbSet<UserRoleTable>? UserRoles { get; set; }
    public DbSet<BusinessPartnerTable>? BusinessPartners { get; set; }
}