using AutoMapper;
using Bamboo.Core.Entities;
using Bamboo.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Mapper.Profiles
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategoryEntity, CreateProductCategoryModel>();
            CreateMap<ProductCategoryEntity, ProductCategoryModel>();

            CreateMap<CreateProductCategoryModel, ProductCategoryEntity>();
            CreateMap<ProductCategoryModel, ProductCategoryEntity>();
        }
    }
}
