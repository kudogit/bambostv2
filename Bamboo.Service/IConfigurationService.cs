using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bamboo.Core.Models;

namespace Bamboo.Service
{
    public interface IConfigurationService
    {
        Task ConfigGeneralInfo(ConfigurationModel generalInfo);
        Task<ConfigurationModel> GetGeneralInfo();
    }
}
