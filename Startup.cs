using identity_2auth_mvc.Data;
using identity_2auth_mvc.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc
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
            services.AddDbContext<ApplicationDbContext>(options =>
                // UseLazyLoadingProxies to solve "navigation properties is return null"
                options.UseLazyLoadingProxies().UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<AppUser, IdentityRole>()
                        .AddEntityFrameworkStores<ApplicationDbContext>()
                        .AddDefaultUI()
                        .AddDefaultTokenProviders();

            // handle return Json partial view
            services.AddControllers().AddNewtonsoftJson(x =>
             x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseDatabaseErrorPage();
            }
            else
            {
                //app.UseStatusCodePagesWithReExecute("/Home/Error/{0}"); // handle view not found
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            // app.Use(async (ctx, next) =>
            // {
            //     await next();

            //     if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
            //     {
            //         //Re-execute the request so the user gets the error page
            //         string originalPath = ctx.Request.Path.Value;
            //         ctx.Items["originalPath"] = originalPath;
            //         ctx.Request.Path = "/error/404";
            //         await next();
            //     }
            // });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Test",
                    pattern: "{controller=Note}/{action=Index}/");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
