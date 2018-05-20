using AutoMapper;
using Bamboo.Core.Entities;
using Bamboo.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Mapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, CreateProductModel>();
            CreateMap<ProductEntity, EditProductModel>()
                .ForMember(x => x.ProductCategoryName, o => o.MapFrom(s => s.ProductCategory.Name));

            CreateMap<CreateProductModel, ProductEntity>();
            CreateMap<EditProductModel, ProductEntity>();
        }
    }
}
