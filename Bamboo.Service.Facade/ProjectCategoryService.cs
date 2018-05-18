using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bamboo.Core.Constants;
using Bamboo.Core.Entities;
using Bamboo.Core.Models;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;
using Bamboo.Mapper;
using Bamboo.Util.Exceptions;

namespace Bamboo.Service.Facade
{
    [ScopeDependency(ServiceType = typeof(IProjectCategoryService))]
    public class ProjectCategoryService : IProjectCategoryService
    {
        private readonly IProjectCategoryRepository _categoryRepository;

        public ProjectCategoryService(IProjectCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<int> Create(CreateProjectCategoryModel model)
        {
            var entity = model.MapTo<ProjectCategoryEntity>();
            var result = _categoryRepository.Add(entity);
            _categoryRepository.SaveChanges();
            return Task.FromResult(result.Id);
        }

        public Task<IQueryable<ProjectCategoryModel>> GetAll()
        {
            var result = _categoryRepository.Get().QueryTo<ProjectCategoryModel>();

            return Task.FromResult(result);
        }

        public Task DeleteAsync(int id)
        {
            var any = _categoryRepository.Get().Any(x => x.Id == id && x.Projects.Any());
            if(any)
                throw new BambooException(ErrorCode.Unknown, "Can not delete, there are already existing projects in project category");
            _categoryRepository.Delete(new ProjectCategoryEntity
            {
                Id = id
            }, true);
            _categoryRepository.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(ProjectCategoryModel model)
        {
            _categoryRepository.Update(model.MapTo<ProjectCategoryEntity>(), x => x.Name);
            _categoryRepository.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
