using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bamboo.Core.Entities;
using Bamboo.Core.Models;

namespace Bamboo.Mapper.Profiles
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<AboutEntity, CreateAboutModel>();

            CreateMap<CreateAboutModel, AboutEntity>();
        }
    }
}
