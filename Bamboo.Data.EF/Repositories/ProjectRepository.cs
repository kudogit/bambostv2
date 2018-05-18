using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Entities;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;

namespace Bamboo.Data.EF.Repositories
{
    [ScopeDependency(ServiceType = typeof(IProjectRepository))]
    public class ProjectRepository : EntityRepository<ProjectEntity>, IProjectRepository
    {
        public ProjectRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
