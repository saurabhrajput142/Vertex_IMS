using AutoMapper;
using Management.Entities;
using Management.Enums;
using Web.Implementation.Contracts;

namespace Web.Implementation.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RoleRequest, RoleEntity>().ForMember(d => d.Status, opt => opt.MapFrom(s => (byte)s.Status));
            CreateMap<UserEntity, UserResponse>().ForMember(d => d.Status, opt => opt.MapFrom(s => (UserStatus)s.Status));
            CreateMap<MenuEntity, MenuRespose>();
        }
    }
}
