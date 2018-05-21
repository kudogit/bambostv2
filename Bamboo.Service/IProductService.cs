using Bamboo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo.Service
{
    public interface IProductService
    {
        Task<int> CreateAsync(CreateProductModel model);
        Task<IQueryable<EditProductModel>> GetAllAsync();
        Task Delete(int id);
        Task UpdateAsync(EditProductModel model);
        Task<EditProductModel> GetById(int id);
    }
}
