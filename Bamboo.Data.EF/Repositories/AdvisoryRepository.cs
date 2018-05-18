using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Entities;
using Bamboo.Data.IRepositories;

namespace Bamboo.Data.EF.Repositories
{
    public class AdvisoryRepository : EntityRepository<AdvisoryEntity>, IAdvisoryRepository
    {
        public AdvisoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
