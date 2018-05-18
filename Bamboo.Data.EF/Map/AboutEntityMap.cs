using Bamboo.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Data.EF.Map
{
    public class AboutEntityMap : BaseEntityMap<AboutEntity>
    {
        public AboutEntityMap(EntityTypeBuilder<AboutEntity> entityBuilder) : base(entityBuilder)
        {
        }
    }
}
