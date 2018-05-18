using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Entities
{
    public class ProjectCategoryEntity : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<ProjectEntity> Projects { get; set; }
    }
}
