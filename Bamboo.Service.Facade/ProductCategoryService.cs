using Bamboo.Core.Constants;
using Bamboo.Core.Entities;
using Bamboo.Core.Models;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;
using Bamboo.Mapper;
using Bamboo.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo.Service.Facade
{
    [ScopeDependency(ServiceType = typeof(IProductCategoryService))]
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _categoryRepository;

        public ProductCategoryService(IProductCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<int> Create(CreateProductCategoryModel model)
        {
            var entity = model.MapTo<ProductCategoryEntity>();
            var result = _categoryRepository.Add(entity);
            _categoryRepository.SaveChanges();
            return Task.FromResult(result.Id);
        }

        public Task<IQueryable<ProductCategoryModel>> GetAll()
        {
            var result = _categoryRepository.Get().QueryTo<ProductCategoryModel>();

            return Task.FromResult(result);
        }

        public Task DeleteAsync(int id)
        {
            var any = _categoryRepository.Get().Any(x => x.Id == id && x.Products.Any());
            if (any)
                throw new BambooException(ErrorCode.Unknown, "Can not delete, there are already existing products in product category");
            _categoryRepository.Delete(new ProductCategoryEntity
            {
                Id = id
            }, true);
            _categoryRepository.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(ProductCategoryModel model)
        {
            _categoryRepository.Update(model.MapTo<ProductCategoryEntity>(), x => x.Name);
            _categoryRepository.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
