using ABEGestionProyectos.Infrastructure;
using ABEGestionProyectos.Services;
using ABEGestionProyectos.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Web
{
    public class Startup
    {

        //Contenedor de dependencias
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<GestionProyectosDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("miCadena")));

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IEpicService, EpicService>();
            services.AddScoped<IUserHistoryService, UserHistoryService>();
            services.AddScoped<ISprintService, SprintService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IChoreService, ChoreService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
