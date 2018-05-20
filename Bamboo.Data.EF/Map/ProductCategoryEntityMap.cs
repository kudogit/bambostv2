using Bamboo.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Data.EF.Map
{
    public class ProductCategoryEntityMap : BaseEntityMap<ProductCategoryEntity>
    {
        public ProductCategoryEntityMap(EntityTypeBuilder<ProductCategoryEntity> entityBuilder) : base(entityBuilder)
        {
        }
    }
}
