using Bamboo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bamboo.Data.EF.Repositories
{
    public abstract class EntityRepository<TEntity> : Repository<DbContext, TEntity>, IEntityRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected EntityRepository(DbContext dbContext) : base(dbContext)
        {
        }
       
    }
}
