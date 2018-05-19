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

namespace Bamboo.Service.Facade
{
    [ScopeDependency(ServiceType = typeof(IProjectService))]
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task<int> CreateAsync(CreateProjectModel model)
        {
            var result = _projectRepository.Add(model.MapTo<ProjectEntity>());
            _projectRepository.SaveChanges();
            return Task.FromResult(result.Id);
        }

        public Task<IQueryable<EditProjectModel>> GetAllAsync()
        {
            var result = _projectRepository.Get().QueryTo<EditProjectModel>();
            return Task.FromResult(result);
        }

        public Task Delete(int id)
        {
            _projectRepository.Delete(new ProjectEntity
            {
                Id = id
            });
            _projectRepository.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(EditProjectModel model)
        {
            var entity = model.MapTo<ProjectEntity>();
            _projectRepository.Update(entity);
            _projectRepository.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<EditProjectModel> GetById(int id)
        {
            var result = _projectRepository.Include(x => x.ProjectCategory).Single(x => x.Id == id).MapTo<EditProjectModel>();
            return Task.FromResult(result);
        }
    }
}
