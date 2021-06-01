using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Asp.netCoreMVC.Data;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Asp.netCoreMVC
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
            //services.AddRazorPages();
            services.AddRazorPages();

            services.AddDbContext<AspnetCoreMVCContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AspnetCoreMVCContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Error");

            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
             
            app.UseRouting();

            app.UseAuthorization();

            //app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
               
                endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Movies}/{action=Index}/{id?}");
            });
        }
    }
}
