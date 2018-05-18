using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Entities;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;

namespace Bamboo.Data.EF.Repositories
{
    [ScopeDependency(ServiceType = typeof(IProjectCategoryRepository))]
    public class ProjectCategoryRepository : EntityRepository<ProjectCategoryEntity>, IProjectCategoryRepository
    {
        public ProjectCategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
