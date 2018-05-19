using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bamboo.Core.Entities;
using Bamboo.Core.Models;

namespace Bamboo.Mapper.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectEntity, CreateProjectModel>();
            CreateMap<ProjectEntity, EditProjectModel>()
                .ForMember(dest => dest.ProjectCategoryName,
                    opt => opt.MapFrom(source => source.ProjectCategory.Name));

            CreateMap<CreateProjectModel, ProjectEntity>();
            CreateMap<EditProjectModel, ProjectEntity>();
        }
    }
}
