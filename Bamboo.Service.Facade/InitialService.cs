using Bamboo.Core.Constants;
using Bamboo.Data.EF;
using Bamboo.DependencyInjection.Attributes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bamboo.Core.Entities;
using Bamboo.Data.IRepositories;
using Bamboo.Util;

namespace Bamboo.Service.Facade
{
    [ScopeDependency(ServiceType = typeof(IInitialService))]
    public class InitialService : IInitialService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<RoleEntity> _roleManager;
        private readonly IConfigurationRepository _configurationRepository;

        public InitialService(UserManager<UserEntity> userManager, 
            RoleManager<RoleEntity> roleManager, 
            IConfigurationRepository configurationRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configurationRepository = configurationRepository;
        }

        public async Task AddRoles()
        {
            //  Create admin
            var admin = new RoleEntity
            {
                Name = "Admin",
                Description = "Admin"
            };
            var result = await _roleManager.CreateAsync(admin).ConfigureAwait(true);

            if(result.Succeeded)
            foreach(var claim in ClaimsDefined.Claims)
            {
                await _roleManager.AddClaimAsync(admin, new System.Security.Claims.Claim(claim.Type, claim.Value)).ConfigureAwait(true);
            }
        }

        public async Task AddUsers()
        {
            //  Add admin
            var result = await _userManager.CreateAsync(new UserEntity
            {
                UserName = "Admin",
                Email = "bamboo.admin@gmail.com"
            }, "1234@Abcd").ConfigureAwait(true);
        }

        public async Task AddUserToRole()
        {
            //  Add admin
            var user = await _userManager.FindByNameAsync("Admin").ConfigureAwait(true);
            if(user != null)
                await _userManager.AddToRolesAsync(user, new List<string>{ 
                    "Admin"
                    }).ConfigureAwait(true);
        }

        public Task AddConfiguration()
        {
            var cfgs = Enum.GetValues(typeof(Configuration.KeyGroup)).Cast<Configuration.KeyGroup>();
            var configEntitys = _configurationRepository.Get();
            foreach (var cfg in cfgs)
            {
                var entity = configEntitys.FirstOrDefault(x => x.Key == cfg.GetDisplayName());
                if(entity == null)
                    _configurationRepository.Add(new ConfigurationEntity
                    {
                        Key = cfg.GetDisplayName(),
                        Value = cfg.GetDescription()
                    });
            }

            _configurationRepository.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
