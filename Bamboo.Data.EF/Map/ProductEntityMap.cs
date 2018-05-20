using Bamboo.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Data.EF.Map
{
    public class ProductEntityMap : BaseEntityMap<ProductEntity>
    {
        public ProductEntityMap(EntityTypeBuilder<ProductEntity> entityBuilder) : base(entityBuilder)
        {
            entityBuilder.HasOne(x => x.ProductCategory).WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductCategoryId);
        }
    }
}
