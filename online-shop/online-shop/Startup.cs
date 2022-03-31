using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OnlineShop.Cart.Domain;
using OnlineShop.Filters;
using OnlineShop.Infrastructure;
using OnlineShop.Middleware;
using OnlineShop.Order.Domain;
using OnlineShop.Payment.Domain;
using OnlineShop.Product.Domain;
using OnlineShop.User.Domain;

namespace OnlineShop
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

            services
                .AddProductModule(Configuration)
                .AddCartModule(Configuration)
                .AddOrderModule(Configuration)
                .AddUserModule(Configuration)
                .AddPaymentModule(Configuration)
                .AddInfrastructureModule(Configuration)
                .AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "OnlineShop API",
                    Version = "v1"
                });

                s.OperationFilter<SwaggerFileOperationFilter>();

                var xmlFiles = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .Where(a => a.GetName().Name.EndsWith("WebApi"))
                    .Select(a => $"{a.GetName().Name}.xml");

                var xmlPaths = xmlFiles
                    .Select(xmlFile => Path.Combine(AppContext.BaseDirectory, xmlFile));

                foreach (var xmlPath in xmlPaths)
                    s.IncludeXmlComments(xmlPath);
            });
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

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineShop API v1");
            });

            app.UseCustomExceptionHandler();

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
