using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo.Service
{
    public interface IFileServive
    {
        Task DeleteAsync(int id);
    }
}
