using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Models.Auth
{
    public class CreateRoleModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class RoleModel : CreateRoleModel
    {
        public int Id { get; set; }
        
    }

}
