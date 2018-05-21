using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bamboo.Core.Entities;

namespace Bamboo.Data.EF.Extensions
{
    public static class BaseEntityExtensions
    {
        public static IQueryable<T> WhereNotDeleted<T>(this IQueryable<T> query) where T :  BaseEntity
        {
            query = query.Where(x => x.DeletedDateTime == null);
            return query;
        }
    }
}
