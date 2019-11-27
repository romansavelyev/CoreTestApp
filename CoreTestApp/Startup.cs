using System.Reflection;
using CoreTestApp.Commands.Broadcast.Create;
using CoreTestApp.Configuration;
using CoreTestApp.Infrastructure.Repository;
using CoreTestApp.Persistance;
using CoreTestApp.Queries.Broadcast.Get;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreTestApp.API
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
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.Configure<SQlDatabaseConnection>(Configuration.GetSection("Connection:Database"));

            services.AddDbContext<CoreTestAppContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CoreTestAppContext")));

            services.AddMediatR(typeof(GetBroadcastQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateBroadcastCommandHandler).GetTypeInfo().Assembly);

            services.AddTransient(typeof(ISqlRepository<>), typeof(SqlRepository<>));

            //TODO: add swagger client app
            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //TODO: add Logging mechanism
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseMvc();
        }
    }
}
