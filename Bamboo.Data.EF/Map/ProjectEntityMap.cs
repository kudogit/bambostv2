using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bamboo.Data.EF.Map
{
    public class ProjectEntityMap : BaseEntityMap<ProjectEntity>
    {
        public ProjectEntityMap(EntityTypeBuilder<ProjectEntity> entityBuilder) : base(entityBuilder)
        {
            entityBuilder.HasOne(x => x.ProjectCategory).WithMany(x => x.Projects)
                .HasForeignKey(x => x.ProjectCategoryId);
        }
    }
}
