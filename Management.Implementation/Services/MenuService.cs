using Management.Entities;
using Management.Implementation.Context;
using Management.Interface;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Management.Implementation.Services
{
    public class MenuService : IMenuService
    {
        private readonly MainDbContext _dbContext;
       
        public MenuService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MenuEntity> GetMenuByUserId_FromProc(int userId)
        {
            return _dbContext.MenuEntities.FromSqlRaw("GetMenuByUserId @UserId", new SqlParameter("UserId", userId)).ToList();
        }

        public IEnumerable<MenuEntity> GetMenuByUserId(int userId)
        {
            var menuList = (from u in _dbContext.UserEntities
                            join ur in _dbContext.UserRoleMappings on u.UserId equals ur.UserRoleMappingId
                            join mr in _dbContext.RoleMenuMappings on ur.RoleId equals mr.RoleId
                            join m in _dbContext.MenuEntities on mr.MenuId equals m.MenuId
                            select m).ToList();

            return menuList;
        }
    }
}
