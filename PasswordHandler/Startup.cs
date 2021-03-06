﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordHandler.Data;
using Microsoft.VisualStudio.Web.BrowserLink;
using Password_Storage;
using Password_Storage.Interfaces;
using Password_Storage.RuleDescriptors;
using AutoMapper;
using PasswordHandler.Utils;
using PasswordStorage;

namespace PasswordHandler
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddDbContext<PasswordContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("PasswordContext")));
            services.AddTransient<IEncrypt, Crypto>();
            services.AddSingleton<IRuleDescriptor, UpperCharDescriptor>();
            services.AddSingleton<IRuleDescriptor, LowerCharDescriptor>();
            services.AddSingleton<IRuleDescriptor, DigitCharDescriptor>();
            services.AddSingleton<IRuleDescriptor, SpecialCharDescriptor>();
            services.AddSingleton<IRuleDescriptor, LengthDescriptor>();
            services.AddSingleton<RuleContainer>();
            services.AddAutoMapper(config => config.AddProfile<MappingProfile>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
