using Bamboo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo.Service
{
    public interface IProductCategoryService
    {
        Task<int> Create(CreateProductCategoryModel model);
        Task<IQueryable<ProductCategoryModel>> GetAll();
        Task DeleteAsync(int id);
        Task UpdateAsync(ProductCategoryModel model);
    }
}
