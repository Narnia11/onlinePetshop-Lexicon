using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using assignment.Models;
using Model.Model;
using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;

namespace assigment
{
    public class Startup

    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            /* for sql connection*/
            services.AddDbContext<ExDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
            /*End for sql connection*/

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ExDBContext>().AddDefaultTokenProviders();

            /*add dependency injection*/
            services.AddScoped<ICategoryRepo, DatabaseCategoryRepo>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IItemRepo, DatabaseItemRepo>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IMediaRepositoryInterface, MediaRepository>();



            /*End add dependency injection*/
            services.AddSwaggerGen();



            services.AddCors();

            // Default Policy
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44351", "http://localhost:4200", "http://localhost:3000")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseStaticFiles();//to able project to load local files

            app.UseSession();
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
            });

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();
            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
