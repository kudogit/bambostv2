using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bamboo.Core.Entities;
using Bamboo.Core.Models;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;
using Bamboo.Mapper;
using Bamboo.Service.Auth;

namespace Bamboo.Service.Facade
{
    [ScopeDependency(ServiceType = typeof(IAboutService))]
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public Task<int> CreateAsync(CreateAboutModel model)
        {
            var entity = model.MapTo<AboutEntity>();
            var result = _aboutRepository.Add(entity);



            _aboutRepository.SaveChanges();
            return Task.FromResult(result.Id);
        }

        public Task<IQueryable<AboutEntity>> GetAbouts()
        {
            return Task.FromResult(_aboutRepository.Get().Where(x=>!x.IsSelected).OrderByDescending(x=>x.LastUpdatedDateTime).AsQueryable());
        }

        public Task<int> UpdateAsync(AboutEntity model)
        {
             _aboutRepository.Update(model);
            _aboutRepository.SaveChanges();
            return Task.FromResult(model.Id);
        }
    }
}
