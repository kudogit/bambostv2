using Bamboo.Core.Entities;
using Bamboo.Data.EF.Map;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Data.EF
{
    public sealed partial class DbContext : IdentityDbContext<UserEntity, RoleEntity, int>
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // ReSharper disable once ObjectCreationAsStatement
            new FileEntityMap(builder.Entity<FileEntity>());
            // ReSharper disable once ObjectCreationAsStatement
            new CarouselEntityMap(builder.Entity<CarouselEntity>());
            // ReSharper disable once ObjectCreationAsStatement
            new AdvisoryEntityMap(builder.Entity<AdvisoryEntity>());
            // ReSharper disable once ObjectCreationAsStatement
            new ProjectCategoryEntityMap(builder.Entity<ProjectCategoryEntity>());
            // ReSharper disable once ObjectCreationAsStatement
            new ProjectEntityMap(builder.Entity<ProjectEntity>());
            // ReSharper disable once ObjectCreationAsStatement
            new ProductCategoryEntityMap(builder.Entity<ProductCategoryEntity>());
            // ReSharper disable once ObjectCreationAsStatement
            new ProductEntityMap(builder.Entity<ProductEntity>());
            // ReSharper disable once ObjectCreationAsStatement
            new ConfigurationEntityMap(builder.Entity<ConfigurationEntity>());
        }
    }
}
