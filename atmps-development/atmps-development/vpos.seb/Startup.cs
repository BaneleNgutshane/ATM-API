using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using vpos.contract.Utils;
using vpos.seb.business;
using vpos.seb.domain.infrastructure;

namespace vpos.seb
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


            services.RegisterBusinessModule(Configuration);

            services.RegisterDomainInfraModule(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ATM API",
                    Version = "v1",
                    Description = "API for an ATM - Validates and performs basic ops including balance enquiries and cash withdraws",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Banele Ngutshane",
                        Email = "banelengutshane@gmail.com",
                        Url = new System.Uri("https://github.com/BaneleNgutshane")
                    }
                }); ;
            });
            services.AddControllers();
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

                context.Database.EnsureCreated();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                var prefix = string.IsNullOrEmpty(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{prefix}/swagger/v1/swagger.json", "ATM Banking API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMiddleware<ExceptionHandler>();


            app.UseHealthChecks("/healthz");
        }
    }
}