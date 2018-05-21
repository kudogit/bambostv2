using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bamboo.Data
{
    public interface IEntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {        
    }
}
