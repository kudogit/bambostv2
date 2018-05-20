using Bamboo.Core.Entities;
using Bamboo.Core.Models;
using Bamboo.Data.IRepositories;
using Bamboo.DependencyInjection.Attributes;
using Bamboo.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo.Service.Facade
{
    [ScopeDependency(ServiceType = typeof(IProductService))]
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<int> CreateAsync(CreateProductModel model)
        {
            var result = _productRepository.Add(model.MapTo<ProductEntity>());
            _productRepository.SaveChanges();
            return Task.FromResult(result.Id);
        }

        public Task<IQueryable<EditProductModel>> GetAllAsync()
        {
            var result = _productRepository.Get().QueryTo<EditProductModel>();
            return Task.FromResult(result);
        }

        public Task Delete(int id)
        {
            _productRepository.Delete(new ProductEntity
            {
                Id = id
            });
            _productRepository.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(EditProductModel model)
        {
            var entity = model.MapTo<ProductEntity>();
            _productRepository.Update(entity);
            _productRepository.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
