using AutoMapper;
using Management.Enums;
using Management.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security;
using Web.Implementation.Attributes;
using Web.Implementation.Contracts;

namespace Web.Implementation.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper, IMenuService menuService)
        {
            _userService = userService;
            _menuService = menuService;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserDetails(int userId)
        {
            if (userId == default)
            {
                throw new ArgumentNullException("userid is not valid");
            }

            var user = _userService.GetById(userId, UserStatus.Active);
            if (user == null)
            {
                throw new SecurityException("user not found");
            }

            var userResponse = _mapper.Map<UserResponse>(user);
            var menuList= _menuService.GetMenuByUserId(userId);
            var menuRespose = _mapper.Map<List<MenuRespose>>(menuList);
            return StatusCode(200, new UserSummary { UserDetail = userResponse, MenuList = menuRespose });
        }
    }
}