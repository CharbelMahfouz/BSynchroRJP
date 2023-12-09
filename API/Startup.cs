using BLL;
using BLL.IServices;
using BLL.Utilities.Extensions;
using BLL.Utilities.Extensions.ServiceExtensions;
using BLL.Utilities.Logging;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using NLog;

using System.IO;
using System.Threading.Tasks;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        }
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options
    =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddCors();

            services.AddSignalR();
            IdentityModelEventSource.ShowPII = true;
            services.ConfigureDbContext(Configuration);
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.ConfigureAuthentication();
            services.ConfigureMailKit(Configuration);
            new ServiceInjector(services).RenderAPI();

            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddRazorPages();
            services.ConfigureSwagger();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseWebSockets();
            app.UseCors(options => options.AllowAnyOrigin()/*.WithOrigins("http://localhost:3000", "http://localhost:3001", "http://localhost:63644", "https://sentinel-admin.netlify.app/", "https://sentinel-admin.netlify.app")*/.AllowAnyHeader()
            .WithMethods("GET", "POST", "OPTIONS", "PUT", "DELETE")/*.AllowCredentials()*/
            );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BSynchroRJP"));
            }
            app.ConfigureCustomExceptionMiddleware();
            
            app.UseSwagger();
            if (env.IsProduction())
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BSynchroRJP");
                    c.DisplayRequestDuration();
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //logger Custom
            //app.ConfigureCustomApiLoggingMiddleware();
            


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });



        }
    }
}
