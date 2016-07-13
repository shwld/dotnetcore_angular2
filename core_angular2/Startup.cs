using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using core_angular2.Providers;
using core_angular2.Models;

namespace core_angular2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var connectionStringsConfig = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("connectionStringsSettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"connectionStringsSettings.{env.EnvironmentName}.json", optional: true)
                .Build();
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables() 
                .AddJsonFile("connectionStringsSettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"connectionStringsSettings.{env.EnvironmentName}.json", optional: true)
                .AddEntityFrameworkConfig(options =>
                    options.UseSqlServer(connectionStringsConfig.GetConnectionString("DefaultContext")));
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<DefaultContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultContext")));

            services.Configure<ConfigData>(options =>
            {
                options.DefaultConnectionString = Configuration.GetConnectionString("DefaultContext");
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
