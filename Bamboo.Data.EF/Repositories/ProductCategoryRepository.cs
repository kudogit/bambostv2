using Bamboo.Core.Entities;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Data.EF.Repositories
{
    [ScopeDependency(ServiceType = typeof(IProductCategoryRepository))]
    class ProductCategoryRepository : EntityRepository<ProductCategoryEntity>, IProductCategoryRepository
    {
        public ProductCategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
