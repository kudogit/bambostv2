using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Entities
{
    public class ProductCategoryEntity : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<ProductEntity> Products { get; set; }
    }
}
