using ApiProjectTaskManagement.Data;
using ApiProjectTaskManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore; // Ensure this is added for UseSqlServer
using ApiProjectTaskManagement.Repository;
using Serilog;
using ApiProjectTaskManagement.Middleware;

namespace ApiProjectTaskManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddControllers();
            services.AddSwaggerGen();


            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog(new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File("logs/api.log", rollingInterval: RollingInterval.Day)
                    .CreateLogger());
            });


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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

          
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task API V1");
                });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Use built-in error page in development mode
            }
            else
            {
                app.UseMiddleware<ExceptionMiddleware>(); // Register custom middleware
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
