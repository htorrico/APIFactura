using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIFactura.Request;
using APIFactura.Response;
using AutoMapper;
using Common;
using Infraestructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace APIFactura
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap(typeof(ResponseBase<>), typeof(ResponseBase<>));
                cfg.CreateMap(typeof(Producto_Response2), typeof(Domain.Producto));
                cfg.CreateMap(typeof(Producto_Response), typeof(Domain.Producto));
                cfg.CreateMap(typeof(Producto_Request), typeof(Domain.Producto));
                cfg.CreateMap(typeof(Exception), typeof(Exception));
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          // services.AddDbContext<ContextFactura>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:Conexion"]));
           services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
