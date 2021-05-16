using AutoMapper;
using Management.Entities;
using Management.Enums;
using Management.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security;
using Web.Implementation.Attributes;
using Web.Implementation.Contracts;

namespace Web.Implementation.Controllers
{
    [Authorize]
    [Route("api/role")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult Create([System.Web.Http.FromBody]RoleRequest role)
        {
            EnsureRoleNameUnique(role.Name, default);

            var roleEntity = _mapper.Map<RoleEntity>(role);
            if (roleEntity == null)
            {
                throw new SecurityException(nameof(RoleEntity));
            }

            roleEntity.RoleMenuMappingEntities = role.MenuIds.Select(id => new RoleMenuMappingEntity
            {
                MenuId = id
            }).ToList();
            roleEntity.CreatedById = GetCurrentUserId();
            roleEntity.CreatedDate = DateTime.Now;
            _roleService.Add(roleEntity);
            return StatusCode(204);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return StatusCode(200, new RoleRequest { Name = "test", Status = RoleStatus.Active });
        }


        private void EnsureRoleNameUnique(string roleName, int roleId)
        {
            var role = _roleService.GetRoleByRoleName(roleName);
            if (role != null && role.RoleId != roleId)
            {
                throw new SecurityException("Duplicate rolename found");
            }
        }
    }
}