using Lil.Busqueda.Interfaces;
using Lil.Busqueda.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Busqueda
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IClientesServices, ClienteServices>();
            services.AddSingleton<IProductosServices, ProductoServices>();
            services.AddSingleton<IVentasServices, VentaServices>();

            services.AddHttpClient("clienteService", c =>
            {
                c.BaseAddress = new Uri(Configuration["Services:Clientes"]);
            });
            services.AddHttpClient("productoService", c =>
            {
                c.BaseAddress = new Uri(Configuration["Services:Productos"]);
            });
            services.AddHttpClient("ventaService", c =>
            {
                c.BaseAddress = new Uri(Configuration["Services:Ventas"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
