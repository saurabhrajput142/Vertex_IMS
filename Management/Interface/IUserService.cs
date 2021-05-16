using Management.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Interface
{
    public interface IMenuService
    {
        IEnumerable<MenuEntity> GetMenuByUserId(int userId);
        IEnumerable<MenuEntity> GetMenuByUserId_FromProc(int userId);
    }
}
