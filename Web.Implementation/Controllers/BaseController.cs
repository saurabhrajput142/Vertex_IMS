using Web.Implementation.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace Web.Implementation.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        public int GetCurrentUserId()
        {
            var claimsIdentity = HttpContext.User;
            return int.Parse(claimsIdentity.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId)?.Value);
        }

        public string GetCurrentUserName()
        {
            var claimsIdentity = HttpContext.User;
            return claimsIdentity.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
        }
    }
}