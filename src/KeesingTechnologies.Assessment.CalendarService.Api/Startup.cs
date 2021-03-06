using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using KeesingTechnologies.Assessment.CalendarService.Api.Data;
using KeesingTechnologies.Assessment.CalendarService.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;

namespace KeesingTechnologies.Assessment.CalendarService.Api
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
            services.AddScoped<IEventsRepository, EventsRepository>();
            services.AddDbContext<EventContext>(options => {
                options.UseSqlite(Configuration.GetConnectionString("Default"));
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Keesing Technologies Assessment, Calendar API", Version = "v1",
                    Description = "Assessment Project: Calendar API",
                    Contact = new OpenApiContact
                    {
                        Name = "Amin Mesbahi, github repository:",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/aminmesbahi"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EventContext context)
        {

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Keesing Technologies Assessment, Calendar API");
                    c.RoutePrefix = string.Empty;
                });


            context.Database.EnsureCreated();
            //commented becuase the SSL error on testing environment
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
