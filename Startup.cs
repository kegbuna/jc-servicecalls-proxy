using System;
using JCServiceCallsProxy.Data;
using JCServiceCallsProxy.Models;
using JCServiceCallsProxy.ServiceCalls;
using JCServiceCallsProxy.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;

namespace JCServiceCallsProxy
{
    public class Startup
    {
        /// <summary>
        /// Startup configuration
        /// </summary>
        /// <param name="env">Provides env information</param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        private IConfigurationRoot Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The collection of services to be used by the api</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", builder =>
                    builder
                        .WithOrigins("http://localhost", "https://localhost", "http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());

                options.AddPolicy("AllowAll", builder => 
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());

                options.AddPolicy("AllowGithub", builder =>
                    builder
                        .WithOrigins("https://kegbuna.github.io")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });


            services.AddOptions();

            services.AddSingleton<IServiceCallApiClient, ServiceCallApiClient>();

            services.Configure<CallClientSettings>(callClientSettings =>
            {
                IConfigurationSection callClientSection = Configuration.GetSection("CallClientSettings");
                callClientSettings.Limit = Int16.Parse(callClientSection["Limit"]);
                callClientSettings.Domain = callClientSection["Domain"];
            });

            services.AddMvc();

            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Jersey City Call Data Api",
                    Description = "Retrieves service calls from the Jersey City PD Database",
                    TermsOfService = "Be Gentle",
                    Contact = new Contact() { Name = "Ken Egbuna", Email = "ken@egbuna.com" }
                });

                options.IncludeXmlComments("api.xml");
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Builds the application</param>
        /// <param name="env">Provides env variables</param>
        /// <param name="loggerFactory">Logs</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseCors("AllowLocalhost");
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseCors("AllowLocalhost");
                app.UseCors("AllowGithub");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
