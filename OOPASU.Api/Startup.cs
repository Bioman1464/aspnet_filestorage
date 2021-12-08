using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OOPASU.Api.Data;
using OOPASU.Api.Repository;
using OOPASU.Domain;

namespace OOPASU.Api
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
            services.AddDbContext<DataContext>(options =>
                {
                    options.UseNpgsql(
                        Configuration.GetConnectionString("DefaultConnection")
                    );
                    options.UseNpgsql(b => b.MigrationsAssembly("OOPASU.Api"));
                }
            );
            services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddControllers();
            services.AddSwaggerGen();

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });

            //Set the limit to 256 MB on multipart body requests
            services.Configure<FormOptions>(options => options.MultipartBodyLengthLimit = 268435456);

            // Add default cors policy
            services.AddCors(options =>
                options.AddPolicy(
                    "default",
                    policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }
                )
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
                app.UseDeveloperExceptionPage();
            }

            //Enable swagger doc generator
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors("default");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}