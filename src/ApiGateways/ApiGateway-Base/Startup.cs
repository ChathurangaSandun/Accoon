﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGateway_Base.Models;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway_Base
{
    public class Startup
    {
        private readonly IConfiguration _cfg;

        public Startup(IConfiguration configuration)
        {
            _cfg = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var authenticationProviderKey = "OcelotKey";
            var identityServerOptions = new IdentityServerOptions();
            _cfg.Bind("IdentityServerOptions", identityServerOptions);
            services.AddAuthentication(identityServerOptions.IdentityScheme)
                .AddIdentityServerAuthentication(authenticationProviderKey, options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Authority = $"http://{identityServerOptions.ServerIP}:{identityServerOptions.ServerPort}";
                    options.ApiName = identityServerOptions.ResourceName;
                    options.SupportedTokens = SupportedTokens.Both;
                }
                );


            services.AddOcelot();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseOcelot().Wait();
        }
    }
}