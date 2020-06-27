using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotenv.net;
using SparkDrums.Data;
using dotenv.net.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SparkDrums.Services.Products;
using SparkDrums.Data.Readers.Products;
using SparkDrums.Data.Writers.Products;
using SparkDrums.Services.Inventories;
using SparkDrums.Data.Readers.Inventories;
using SparkDrums.Services.Customers;
using SparkDrums.Data.Writers.Inventories;
using SparkDrums.Data.Readers.Customers;
using SparkDrums.Data.Writers.Customers;
using SparkDrums.Services.Orders;
using SparkDrums.Data.Readers.Orders;
using SparkDrums.Data.Writers.Orders;

namespace SparkDrums.Api
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
            // set up Cors policy
            services.AddCors(options => options
               .AddPolicy(name: "SparkDrumsPolicy",
               builder => builder
               .WithOrigins("http://localhost:8080")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials())
               );

            services.AddControllers();

            // set up dotenv to grab the env vars
            DotEnv.Config(true, "../../.env");
            var envReader = new EnvReader();
            var connectionString = envReader.GetStringValue("DEV_CONNECTION_STRING");

            // set up Postgres
            services.AddDbContext<SparkDrumsDbContext>(options =>
            {
                options.EnableDetailedErrors();
                options.UseNpgsql(connectionString);
            });

            // register dependencies in the IOC container. When I ask for IProductsService, please use the ProductsService implementation
            // AddTransient means we want a simple, short-lived instance of a ProductsService when its behaviour is requested
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IProductsReader, ProductsReader>();
            services.AddTransient<IProductsWriter, ProductsWriter>();

            services.AddTransient<IInventoriesService, InventoriesService>();
            services.AddTransient<IInventoriesReader, InventoriesReader>();
            services.AddTransient<IInventoriesWriter, InventoriesWriter>();

            services.AddTransient<ICustomersService, CustomersService>();
            services.AddTransient<ICustomersReader, CustomersReader>();
            services.AddTransient<ICustomersWriter, CustomersWriter>();

            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IOrdersReader, OrdersReader>();
            services.AddTransient<IOrdersWriter, OrdersWriter>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            // only allow certain clients to consume this service
            app.UseCors("SparkDrumsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                .RequireCors("SparkDrumsPolicy");
            });

            app.UseHttpsRedirection();
        }
    }
}
