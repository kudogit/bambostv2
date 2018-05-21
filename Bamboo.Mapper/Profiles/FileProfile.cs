using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bamboo.Core.Entities;
using Bamboo.Core.Models.File;

namespace Bamboo.Mapper.Profiles
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<FileBase64Model, FileEntity>();
            CreateMap<FileEntity, FileModel>();
            CreateMap<FileModel, FileEntity>();
        }
    }
}
