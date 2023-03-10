using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartDevices.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartDevices.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SmartDevices
{
    public class Startup
    {
        private IConfigurationRoot _configurationString; 
        public Startup(IWebHostEnvironment env)
        {
            _configurationString = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(mvcOtions => 
            {
                mvcOtions.EnableEndpointRouting = false;
            });
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_configurationString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllDevices, DeviceRepository>();
            services.AddTransient<IAllRooms, RoomRepository>();
            services.AddTransient<IAllHouses, HouseRepository>();
            services.AddTransient<IAllUsers, UserRepository>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Users/Login");
                });
            services.AddMvc();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
            }
        }
    }
}
