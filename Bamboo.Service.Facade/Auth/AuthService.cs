using Bamboo.Core.Models.Auth;
using Bamboo.Data.EF;
using Bamboo.Service.Auth;
using Bamboo.Util.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bamboo.DependencyInjection.Attributes;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Constants;
using Bamboo.Mapper;

namespace Bamboo.Service.Facade.Auth
{
    [ScopeDependency(ServiceType = typeof(IAuthService))]
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly RoleManager<RoleEntity> _roleManager;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager,
            RoleManager<RoleEntity> roleManager, IPasswordHasher<UserEntity> passwordHasher,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public Task<IdentityResult> CreateAsync(CreateAuthModel model)
        {
            var result = _userManager.CreateAsync(model.MapTo<UserEntity>(), model.Password);

            return result;
        }

        public async Task<TokenModel> CreateTokenAsync(LoginModel model)
        {
                var user = await _userManager.FindByNameAsync(model.UserName).ConfigureAwait(true);

                if (user == null)
                    throw new BambooException(Core.Constants.ErrorCode.NotFoundUser);

            if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) !=
                PasswordVerificationResult.Success) throw new BambooException(Core.Constants.ErrorCode.PasswordInvalid);

            var userRoles = await _userManager.GetRolesAsync(user).ConfigureAwait(true);

            var roleEntities = _roleManager.Roles.Where(x => userRoles.Contains(x.Name));

            var userClaims = new List<Claim>();
            foreach (var roleEntity in roleEntities)
            {
                userClaims.AddRange(await _roleManager.GetClaimsAsync(roleEntity).ConfigureAwait(true));
            }

            userClaims.AddRange(new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                });

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityToken:Key"]));

            var signingcredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(issuer: _configuration["JwtSecurityToken:Issuer"],
                audience: _configuration["JwtSecurityToken:Audience"],
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signingcredentials);

            return new TokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Expiration = jwtSecurityToken.ValidTo
            };
        }

        public async Task AddToRolesAsync(string userName, List<RoleModel> roles)
        {
            var roleNames = roles.Select(x => x.Name);

            //  Check userId
            var user = await _userManager.FindByNameAsync(userName).ConfigureAwait(true);
            if(user == null)
                throw new BambooException(Core.Constants.ErrorCode.NotFoundUser);

            var result = await _userManager.AddToRolesAsync(user, roleNames).ConfigureAwait(true);
            if(!result.Succeeded)
                throw new Exception(result.Errors.First().Description);
        }
    }
}
