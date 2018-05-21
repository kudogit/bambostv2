using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Bamboo.Util
{
    public static class AppSettings
    {
        public static string BaseUrl => Environment.CurrentDirectory;
        public static string FileUrl { get; set; }
        
    }

    public static class AppSettingsHelper
    {
        public static void Setup(IConfiguration configuration)
        {
            AppSettings.FileUrl = configuration.GetSection("Files")["upload"];
        }
    }
}
