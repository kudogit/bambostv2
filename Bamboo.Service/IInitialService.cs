using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo.Service
{
    public interface IInitialService
    {
        Task AddUsers();

        Task AddRoles();

        Task AddUserToRole();

        Task AddConfiguration();
    }
}
