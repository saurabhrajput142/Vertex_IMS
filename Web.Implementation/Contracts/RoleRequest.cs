using Management.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Implementation.Contracts
{
    public class RoleRequest
    {

        [Required(ErrorMessage = "Name filed is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Length is not correct")]
        public string Name { get; set; }

        public RoleStatus Status { get; set; }

        public IEnumerable<int> MenuIds { get; set; }
    }
}
