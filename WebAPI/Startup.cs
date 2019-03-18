using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using FIM.API.Modules.MUser;
using WebAPI.Modules.Repository;

namespace WebAPI
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    // Format properties naming
                    var resolver = options.SerializerSettings.ContractResolver;
                    if (resolver != null)
                        (resolver as DefaultContractResolver).NamingStrategy = null;

                    // Format json
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });

            // Connect to DB use SQL Server
            services.AddDbContext<RFQDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddCors();

            services.AddMvc()
                    .AddControllersAsServices();

            services.AddTransient<IRFQService, RFQService>();
            services.AddTransient<IRFQRepository, RFQRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Exception
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Config port for front-end Angular
            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            );

            // User MVC for project
            app.UseMvc();

            //app.UseMvcWithDefaultRoute();
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
        }
    }
}
