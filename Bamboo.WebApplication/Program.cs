using Bamboo.Data.EF;
using Bamboo.Service;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Bamboo.WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
                
            OnApplicationStart(host).ConfigureAwait(true);
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        private static async Task OnApplicationStart(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var initialService = services.GetService<IInitialService>();

                //  Migrate database
                var dbContext = services.GetRequiredService<Data.EF.DbContext>();
                dbContext.Database.Migrate();

                await initialService.AddRoles().ConfigureAwait(true);
                await initialService.AddUsers().ConfigureAwait(true);
                await initialService.AddUserToRole().ConfigureAwait(true);
                await initialService.AddConfiguration().ConfigureAwait(true);

            }
        }
    }
}
