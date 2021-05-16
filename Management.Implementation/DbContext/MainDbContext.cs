using Management.Entities;
using Microsoft.EntityFrameworkCore;

namespace Management.Implementation.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> option) : base(option)
        {
        }
        
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<MenuEntity> MenuEntities { get; set; }
        public DbSet<RoleMenuMappingEntity> RoleMenuMappings { get; set; }
        public DbSet<UserRoleMappingEntity> UserRoleMappings { get; set; }


    }
}
