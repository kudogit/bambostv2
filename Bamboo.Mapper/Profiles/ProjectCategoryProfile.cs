using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bamboo.Core.Entities;
using Bamboo.Core.Models;

namespace Bamboo.Mapper.Profiles
{
    public class ProjectCategoryProfile : Profile
    {
        public ProjectCategoryProfile()
        {
            CreateMap<ProjectCategoryEntity, CreateProjectCategoryModel>();
            CreateMap<ProjectCategoryEntity, ProjectCategoryModel>();

            CreateMap<CreateProjectCategoryModel, ProjectCategoryEntity>();
            CreateMap<ProjectCategoryModel, ProjectCategoryEntity>();
        }
    }
}
