using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BobStore.Infra.DataContexts;
using BobStore.Infra.StoreContext.Repositories;
using BobStore.Infra.StoreContext.Services;
using BoBStore.Domain.StoreContext.Repositories;
using BoBStore.Domain.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BoBStore.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC
            services.AddMvc();

            // Injeção de Dependência
            services.AddScoped<BoBDataContext, BoBDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/routing?view=aspnetcore-5.0
            // Adiciona correspondência de rota ao pipeline de middleware.
            app.UseRouting();

            // Adiciona a execução de ponto de extremidade ao pipeline de middleware
            app.UseEndpoints(endpoints => endpoints.MapControllers());

        }
    }
}
