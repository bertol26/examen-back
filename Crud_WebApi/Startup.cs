using Crud_WebApi.Repositories.Interfaces;
using Crud_WebApi.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Crud_WebApi.Services.Interfaces;
using Crud_WebApi.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.OpenApi.Models;
using Crud_WebApi.Context;

namespace Crud_WebApi
{
    public class Startup
    {
        private const string AllowAllOriginsPolicy = "AllowAllOriginsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContextExamen>(options => options.UseSqlServer(Configuration["prueba:cn"]));

            services.AddCors(o => o.AddPolicy(AllowAllOriginsPolicy, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();

            }));
            services.AddControllers();
            AddSwagger(services);

            services.AddScoped<IAlumnoService, AlumnoService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<INotasService, NotasService>();

            services.AddTransient<IAlumnoRepository, AlumnoRepository>();
            services.AddTransient<ICursoRepository, CursoRepository>();
            services.AddTransient<INotasRepository, NotasRepository>();
        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Prueba {groupName}",
                    Version = groupName,
                    Description = "Prueba API",
                    Contact = new OpenApiContact
                    {
                        Name = "Prueba",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
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

            /*Start - Cors*/
            app.UseCors(AllowAllOriginsPolicy);
            app.Use((context, next) =>
            {
                context.Items["__CorsMiddlewareInvoked"] = true;
                return next();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
