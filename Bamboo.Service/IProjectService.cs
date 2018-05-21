using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bamboo.Core.Models;

namespace Bamboo.Service
{
    public interface IProjectService
    {
        Task<int> CreateAsync(CreateProjectModel model);
        Task<IQueryable<EditProjectModel>> GetAllAsync();
        Task Delete(int id);
        Task UpdateAsync(EditProjectModel model);
        Task<EditProjectModel> GetById(int id);
    }
}
