using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using Bamboo.Core;
using Bamboo.Core.Validators;
using Bamboo.Data.EF;
using Bamboo.DependencyInjection;
using Bamboo.Mapper;
using Bamboo.SignalR;
using Bamboo.Util;
using Bamboo.WebApplication.Filters.Exception;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using DbContext = Bamboo.Data.EF.DbContext;

namespace Bamboo.WebApplication
{
    public class Startup
    {
        private const string DefaultCorsPolicyName = "MyPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
               sqlOptions => sqlOptions.MigrationsAssembly("Bamboo.Data.EF")));
            services.AddIdentity<UserEntity, RoleEntity>()
                .AddEntityFrameworkStores<DbContext>()
                .AddDefaultTokenProviders();

            AppSettingsHelper.Setup(Configuration);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = Configuration["JwtSecurityToken:Issuer"],
                    ValidAudience = Configuration["JwtSecurityToken:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityToken:Key"])),
                    ValidateLifetime = true
                };
            });

            services.AddDependencyScanning().ScanFromAssembly(new AssemblyName(nameof(Bamboo)))
                .AddSignalRService()
                .AddAuthorize()
                .AddAutoMapper(nameof(Bamboo));

            services.AddCors(options => options.AddPolicy(DefaultCorsPolicyName,
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

            services.AddMvc(options =>
            {
                //  Add exception filter
                options.Filters.Add(typeof(ApiExceptionFilter));
            })
            .AddModelValidator();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(DefaultCorsPolicyName);


            app.UseAuthentication();

            app.UseSignalRService();

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            }).UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "index.html" } })
             .UseStaticFiles();

            app.UseMvc();

        }
    }
}
