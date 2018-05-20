using Bamboo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bamboo.Core.Models.File;

namespace Bamboo.Data.File
{
    public interface IFileRepository : IEntityRepository<FileEntity>
    {
        Task<FileEntity> SaveImage(FileBase64Model model);
    }
}
