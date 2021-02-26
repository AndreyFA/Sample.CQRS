using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sample.CQRS.Application.PipelineBehaviors;
using Sample.CQRS.Domain;
using Sample.CQRS.Infra.Cache;
using Sample.CQRS.Infra.Oracle;
using System;

namespace Sample.CQRS.WebAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {


            services
                .AddOracleRepositories()
                .AddCacheRepositories()
                .AddDomainDependencies();

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CreateNewCustomerBehavior<,>));
            services.AddMediatR(AppDomain.CurrentDomain.Load("Sample.CQRS.Application"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sample.CQRS.WebAPI", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                    .UseSwagger()
                    .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample.CQRS.WebAPI v1"));
            }

            app.UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}