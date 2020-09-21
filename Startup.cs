using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RTBSharp.Models;
using qSharp;

namespace RTBSharp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _kdbConnectorOptions = new KdbConnectorOptions();
            configuration.GetSection(KdbConnectorOptions.KdbOptions).Bind(_kdbConnectorOptions);
        }

        public IConfiguration Configuration { get; }
        private readonly KdbConnectorOptions _kdbConnectorOptions;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // open a connection to kdb process
            var q = new QBasicConnection(
                _kdbConnectorOptions.Host,
                _kdbConnectorOptions.Port,
                _kdbConnectorOptions.UserName,
                _kdbConnectorOptions.Password,
                _kdbConnectorOptions.Encoding
            );

            q.Open();

            // pass it to controllers via dependency injection
            services.AddSingleton<QBasicConnection>(q);


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
