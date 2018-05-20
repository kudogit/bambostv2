using Bamboo.Core.Entities;
using Bamboo.Data.File;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bamboo.Core.Models.File;
using Bamboo.DependencyInjection.Attributes;
using Bamboo.Util;

namespace Bamboo.Data.EF.Repositories.File
{
    [ScopeDependency(ServiceType = typeof(IFileRepository))]
    public class FileRepository : EntityRepository<FileEntity>, IFileRepository
    {
        public FileRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<FileEntity> SaveImage(FileBase64Model model)
        {
            var url = await FileHelper.SaveImage(model.Value.ConvertToStream(), model.Name).ConfigureAwait(true);
            var result = Add(new FileEntity
            {
                Name = model.Name,
                Url = url
            });

            SaveChanges();

            return result;
        }
    }
}
