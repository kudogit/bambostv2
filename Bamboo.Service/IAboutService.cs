using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bamboo.Core.Entities;
using Bamboo.Core.Models;

namespace Bamboo.Service
{
    public interface IAboutService
    {
        Task<int> CreateAsync(CreateAboutModel model);
        Task<IQueryable<AboutEntity>> GetAbouts();
        Task<int> UpdateAsync(AboutEntity model);
    }
}
