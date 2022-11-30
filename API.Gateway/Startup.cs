using API.Gateway.HttpMessajeHandler.Interfaces;
using API.Gateway.HttpMessajeHandler.MessageHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using TiendaServicios.Api.Gateway.ImplementRemote;

namespace API.Gateway
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

            services.AddSingleton<IClienteConsulta, ClienteConsulta>();
            services.AddSingleton<ICuentaConsulta, CuentaConsulta>();

            services.AddHttpClient("ClienteServicio", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Cliente"]);
            });
            services.AddHttpClient("CuentaServicio", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Cuenta"]);
            });

            services.AddOcelot().AddDelegatingHandler<ReporteHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            await app.UseOcelot();
        }
    }
}
