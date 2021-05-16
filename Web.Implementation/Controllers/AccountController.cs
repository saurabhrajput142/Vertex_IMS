using AutoMapper;
using Management.Entities;
using Management.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web.Implementation.Contracts;
using Web.Implementation.Helpers;

namespace Web.Implementation.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AccountController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]AuthenticateRequest loginRequest)
        {
           var user= _userService.Authenticate(loginRequest.Username, loginRequest.Password);
            if (user == null)
            {
                return StatusCode(200, null);
            }

            return StatusCode(200, new AuthenticateResponse(user, generateJwtToken(user)));
        }

        private string generateJwtToken(UserEntity user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = new Dictionary<string, object> {
                { JwtRegisteredClaimNames.Sub, user.UserName },
                {JwtRegisteredClaimNames.NameId, user.UserId }
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Claims = claims
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}