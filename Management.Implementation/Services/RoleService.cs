using Management.Entities;
using Management.Enums;
using Management.Implementation.Context;
using Management.Interface;
using System.Linq;

namespace Management.Implementation.Services
{
    public class RoleService : IRoleService
    {
        private readonly MainDbContext _dbContext;
        public RoleService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(RoleEntity roleEntity)
        {
            roleEntity.Code = GenrateRoleCode();
            _dbContext.RoleEntities.Add(roleEntity);
            _dbContext.SaveChanges();
        }

        public RoleEntity GetRoleByRoleName(string roleName)
        {
            return _dbContext.RoleEntities.FirstOrDefault(
                role => role.Name == roleName &&
                role.Status != (byte)RoleStatus.Deleted);
        }

        private string GenrateRoleCode()
        {
            string maxCode = "R001";
            var lastRole = _dbContext.RoleEntities.OrderByDescending(u => u.RoleId).FirstOrDefault();
            if (lastRole != null)
            {
                int.TryParse(lastRole.Code.Substring(1), out int lastCodeInt);
                string result = (lastCodeInt + 1).ToString().PadLeft(3, '0');
                maxCode = "R" + result;
            }
            return maxCode;
        }
    }
}
