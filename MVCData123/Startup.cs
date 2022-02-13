using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MVCData123.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData123.Models;
using Microsoft.AspNetCore.Identity;

namespace MVCData123
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<PersonContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<PersonContext>();


            services.AddControllersWithViews();
            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "People",
                    pattern: "{controller=People}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                   name: "Ajax",
                   pattern: "{controller=Ajax}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                   name: "EntityFramework",
                   pattern: "{controller=EntityFramework}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                   name: "IDCities",
                   pattern: "{controller=IDCities}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                   name: "IDCountries",
                   pattern: "{controller=IDCountries}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                   name: "IDPeople",
                   pattern: "{controller=IDPeople}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                   name: "IDLanguages",
                   pattern: "{controller=IDLanguages}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                   name: "IDUsers",
                   pattern: "{controller=IDUsers}/{action=Index}/{id?}"
                );
                endpoints.MapRazorPages();

            });
        }
    }
}
