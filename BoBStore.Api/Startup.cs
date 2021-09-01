using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BobStore.Infra.DataContexts;
using BobStore.Infra.StoreContext.Repositories;
using BobStore.Infra.StoreContext.Services;
using BoBStore.Domain.StoreContext.Handlers;
using BoBStore.Domain.StoreContext.Repositories;
using BoBStore.Domain.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Elmah.Io.AspNetCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using BoBStore.Shared;

namespace BoBStore.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public static IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            // Config Settings
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            // Add MVC
            services.AddMvc();

            // Comprime a API
            services.AddResponseCompression();

            // Injeção de Dependência
            services.AddScoped<BoBDataContext, BoBDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustommerHandler, CustommerHandler>();

            // Documentação com Swagger
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "BoB Store", Version = "v1" });
            });

            // Configura os Logs
            services.AddElmahIo(o =>
            {
                o.ApiKey = "93ffcd6f08de4de7bf3b6e998f11d3c9";
                o.LogId = new Guid("f870932b-a55a-4932-96a2-893c1c8649ff");
            });

            // Pega a connection string do appsettings.json
            Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // Comprime a API
            app.UseResponseCompression();

            // https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/routing?view=aspnetcore-5.0
            // Adiciona correspondência de rota ao pipeline de middleware.
            app.UseRouting();

            // Adiciona a execução de ponto de extremidade ao pipeline de middleware
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            // Documenta a APIs
            app.UseSwagger();

            // Gera documentação em JSON
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BoB Store v1"));

            // Gerar Logs
            app.UseElmahIo();
        }
    }
}
