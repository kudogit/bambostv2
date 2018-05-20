using Bamboo.Core.Entities;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Data.EF.Repositories
{
    [ScopeDependency(ServiceType = typeof(IProductRepository))]
    public class ProductRepository : EntityRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
