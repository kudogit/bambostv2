using Bamboo.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bamboo.Util
{
    public static class SystemUtils
    {
        public static string GetDisplayName(this ErrorCode sugarExceptionDefine)
        {
            return sugarExceptionDefine.GetType().GetMember(sugarExceptionDefine.ToString()).First().GetCustomAttribute<DisplayAttribute>().Name;
        }


        public static string GetDisplayName(this Enum value)
        {
            return value.GetType().GetMember(value.ToString()).First().GetCustomAttribute<DisplayAttribute>().Name;
        }

        public static string GetDescription(this Enum value)
        {
            return value.GetType().GetMember(value.ToString()).First().GetCustomAttribute<DisplayAttribute>().Description;
        }
    }
}
