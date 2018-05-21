using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bamboo.Core.Entities;
using Bamboo.Data.EF;
using Bamboo.Data.EF.Repositories;
using Bamboo.Data.File;
using Bamboo.DependencyInjection.Attributes;

namespace Bamboo.Service.Facade
{
    [ScopeDependency(ServiceType = typeof(IFileServive))]
    public class FileService : IFileServive
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }


        public Task DeleteAsync(int id)
        {
            _fileRepository.Delete(new FileEntity
            {
                Id = id
            }, true);
            _fileRepository.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
