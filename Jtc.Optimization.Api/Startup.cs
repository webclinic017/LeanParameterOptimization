﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jtc.Optimization.Transformation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Jtc.Optimization.Api
{
    public class Startup
    {
        private const string PolicyName = "AllowAnyOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors(options => options.AddPolicy(PolicyName, builder => builder.AllowAnyOrigin()));
            services.AddSingleton(Configuration);
            services.AddSingleton<CSharpRemoteCompiler, CSharpRemoteCompiler>();
            services.AddSingleton<IMscorlibProvider, MscorlibProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors(PolicyName);
        }
    }
}
