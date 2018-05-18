using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bamboo.Core.Constants;
using Bamboo.Core.Models;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;
using Bamboo.Mapper;
using Bamboo.Util;

namespace Bamboo.Service.Facade
{
    [ScopeDependency(ServiceType = typeof(IConfigurationService))]
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public Task ConfigGeneralInfo(ConfigurationModel model)
        {
            var entity =
                _configurationRepository.GetSingle(x => x.Key == Configuration.KeyGroup.GeneralInfo.GetDisplayName());

            entity.Value = model.Value;

            _configurationRepository.Update(entity, x => x.Value);
            _configurationRepository.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<ConfigurationModel> GetGeneralInfo()
        {
            var result = _configurationRepository
                .GetSingle(x => x.Key == Configuration.KeyGroup.GeneralInfo.GetDisplayName())
                .MapTo<ConfigurationModel>();
            return Task.FromResult(result);
        }
    }
}
