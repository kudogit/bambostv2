using AutoMapper;
using Bamboo.Core.Models.Auth;
using Bamboo.Data.EF;

namespace Bamboo.Mapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, CreateAuthModel>();
        }
    }
}
