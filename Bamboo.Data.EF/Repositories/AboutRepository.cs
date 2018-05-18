using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Entities;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;

namespace Bamboo.Data.EF.Repositories
{
    [ScopeDependency(ServiceType = typeof(IAboutRepository))]
    public class AboutRepository : EntityRepository<AboutEntity>, IAboutRepository
    {
        public AboutRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
