using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bamboo.Data.EF.Map
{
    public class ConfigurationEntityMap : BaseEntityMap<ConfigurationEntity>
    {
        public ConfigurationEntityMap(EntityTypeBuilder<ConfigurationEntity> entityBuilder) : base(entityBuilder)
        {
        }
    }
}
