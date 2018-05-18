using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using Bamboo.DependencyInjection.Attributes;
using Bamboo.Mapper.Profiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace Bamboo.Mapper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services, string assemblyName)
        {
            ScanAssembly(services, assemblyName);
            services.AddSingleton(AutoMapper.Mapper.Configuration);
            return services;
        }

        public static void ScanAssembly(IServiceCollection services, string assemblyName)
        {
            var folderFullPath = Path.GetFullPath(PlatformServices.Default.Application.ApplicationBasePath);

            var listDllFileFullPath = Directory.GetFiles(folderFullPath, assemblyName + ".Mapper.dll").ToList();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                listDllFileFullPath.ForEach(path =>
                {
                    RegisterProfiles(cfg,services, path);
                });
            });
        }

        private static void RegisterProfiles(IMapperConfigurationExpression cfg, IServiceCollection services, string path)
        {
            var assembly = Assembly.LoadFrom(path);
            var types = assembly.GetTypes().Where(x => x.BaseType == typeof(Profile));

            foreach (var type in types)
            {
                 cfg.AddProfile(type);
            }
        }
    }
}
