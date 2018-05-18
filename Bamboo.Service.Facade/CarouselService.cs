using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bamboo.Core.Constants;
using Bamboo.Core.Entities;
using Bamboo.Core.Models.Carousel;
using Bamboo.Data.File;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;
using Bamboo.Util;
using Bamboo.Util.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Bamboo.Service.Facade
{
    [ScopeDependency(ServiceType = typeof(ICarouselService))]
    public class CarouselService : ICarouselService
    {
        private readonly ICarouselRepository _carouselRepository;
        private readonly IFileRepository _fileRepository;
        private readonly ConfigSettings _configSettings;

        public CarouselService(ICarouselRepository carouselRepository, IFileRepository fileRepository,
            ConfigSettings configSettings)
        {
            _carouselRepository = carouselRepository;
            _fileRepository = fileRepository;
            _configSettings = configSettings;
        }

    }
}
