using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bamboo.Core.Models;

namespace Bamboo.Service
{
    public interface IProjectCategoryService
    {
        Task<int> Create(CreateProjectCategoryModel model);
        Task<IQueryable<ProjectCategoryModel>> GetAll();
        Task DeleteAsync(int id);
        Task UpdateAsync(ProjectCategoryModel model);
    }
}
