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

        public async Task<string> SaveImage(FileBase64Model model, int size = 150, int quality = 75)
        {
            var url = await FileHelper.SaveImage(model.Value.ConvertToStream(), model.Name, size: size, quality: quality).ConfigureAwait(true);

            return url;
        }
    }
}
