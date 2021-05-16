using Management.Entities;

namespace Management.Interface
{
    public interface IRoleService
    {
        void Add(RoleEntity roleEntity);
        RoleEntity GetRoleByRoleName(string roleName);
    }
}
