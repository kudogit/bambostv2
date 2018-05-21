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
            CreateMap<ProjectEntity, EditProjectModel>()
                .ForMember(x => x.Files, opt => opt.Ignore())
                .ForMember(dest => dest.ProjectCategoryName, opt => opt.MapFrom(source => source.ProjectCategory.Name))
                .ForMember(dest => dest.FileModels, opt => opt.MapFrom(s => s.Files));

            CreateMap<CreateProjectModel, ProjectEntity>()
                .ForMember(x => x.Files, opt => opt.Ignore());
            CreateMap<EditProjectModel, ProjectEntity>()
                .ForMember(x => x.Files, opt => opt.Ignore());
        }
    }
}
