using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bamboo.Data.EF.Map
{
    public class AdvisoryEntityMap : BaseEntityMap<AdvisoryEntity>
    {
        public AdvisoryEntityMap(EntityTypeBuilder<AdvisoryEntity> entityBuilder) : base(entityBuilder)
        {

        }
    }
}
