
using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;

namespace Bamboo.Mapper
{
    public static class MapperSystemUtil
    {
        public static TDestination MapTo<TDestination>(this object source) where TDestination : class, new()
        {
            return AutoMapper.Mapper.Map<TDestination>(source);
        }

        public static IQueryable<TDestination> QueryTo<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapper.Mapper.Configuration, null, membersToExpand);
        }
    }
}
