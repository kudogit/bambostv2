using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Entities;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;

namespace Bamboo.Data.EF.Repositories
{
    [ScopeDependency(ServiceType = typeof(IConfigurationRepository))]
    public class ConfigurationRepository : EntityRepository<ConfigurationEntity>, IConfigurationRepository
    {
        public ConfigurationRepository(DbContext dbContext) : base(dbContext)
        {
        }

    }
}
