using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Entities
{
    public class ConfigurationEntity : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
