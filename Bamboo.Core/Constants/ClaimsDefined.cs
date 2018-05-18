using Bamboo.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Constants
{
    public static class ClaimsDefined
    {
        public static List<ClaimModel> Claims = new List<ClaimModel>
        {
            new ClaimModel{ Type = ClaimsConst.ClaimsValues.ViewRole, Value = ClaimsConst.ClaimsValues.ViewRole },
            new ClaimModel{ Type = ClaimsConst.ClaimsValues.CreateRole, Value = ClaimsConst.ClaimsValues.CreateRole },
            new ClaimModel{ Type = ClaimsConst.ClaimsValues.UpdateRole, Value = ClaimsConst.ClaimsValues.UpdateRole },
            new ClaimModel{ Type = ClaimsConst.ClaimsValues.DeleteRole, Value = ClaimsConst.ClaimsValues.DeleteRole }
        };

    }

    //  Defined claims
    public static class ClaimsConst
    {
        public static class ClaimsValues
        {
            public const string ViewRole = "role.view";
            public const string CreateRole = "role.create";
            public const string UpdateRole = "role.update";
            public const string DeleteRole = "role.delete";
        }
    }
}
