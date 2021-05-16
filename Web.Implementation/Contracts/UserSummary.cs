using System.Collections.Generic;

namespace Web.Implementation.Contracts
{
    public class UserSummary
    {
        public UserResponse UserDetail { get; set; }

        public List<MenuRespose> MenuList { get; set; }
    }
}
