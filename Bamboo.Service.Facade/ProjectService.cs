using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bamboo.Core.Entities;
using Bamboo.Core.Models;
using Bamboo.Data.File;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;
using Bamboo.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Bamboo.Service.Facade
{
    [ScopeDependency(ServiceType = typeof(IProjectService))]
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IFileRepository _fileRepository;

        public ProjectService(IProjectRepository projectRepository, IFileRepository fileRepository)
        {
            _projectRepository = projectRepository;
            _fileRepository = fileRepository;
        }

        public async Task<int> CreateAsync(CreateProjectModel model)
        {
            var entity = model.MapTo<ProjectEntity>();
            entity.Files = new List<FileEntity>();
            if(model.Files != null)
                foreach (var file in model.Files)
                {
                    var url = await _fileRepository.SaveImage(file, 300).ConfigureAwait(true);
                    entity.Files.Add(new FileEntity
                    {
                        CreatedDateTime = DateTimeOffset.UtcNow,
                        Name = file.Name,
                        Url = url
                    });
                }

            var result = _projectRepository.Add(entity);
            _projectRepository.SaveChanges();
            return result.Id;
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

        public async Task UpdateAsync(EditProjectModel model)
        {
            var entity = model.MapTo<ProjectEntity>();
            entity.Files = new List<FileEntity>();
            if(model.Files != null)
                foreach (var file in model.Files)
                {
                    var url = await _fileRepository.SaveImage(file, 300).ConfigureAwait(true);
                    entity.Files.Add(new FileEntity
                    {
                        CreatedDateTime = DateTimeOffset.UtcNow,
                        Name = file.Name,
                        Url = url
                    });
                }
            _projectRepository.Update(entity);
            _projectRepository.SaveChanges();
        }

        public Task<EditProjectModel> GetById(int id)
        {
            var result = _projectRepository.Include(x => x.ProjectCategory).Include(x => x.Files).Single(x => x.Id == id).MapTo<EditProjectModel>();
            return Task.FromResult(result);
        }
    }
}
