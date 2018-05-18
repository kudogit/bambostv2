using Bamboo.Core.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core
{
    public static class AuthorizeIServiceCollectionExtention
    {
        public static IServiceCollection AddAuthorize(this IServiceCollection services)
        {
            services.AddAuthorization(options => {
                ClaimsDefined.Claims.ForEach(claim =>
                {
                    options.AddPolicy(claim.Value, policy =>
                    {
                        policy.RequireClaim(claim.Type, claim.Value);
                    });
                });
            });
            return services;
        }
    }
}
