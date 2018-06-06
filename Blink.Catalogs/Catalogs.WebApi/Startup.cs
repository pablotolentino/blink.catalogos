using AutoMapper;
using Catalogs.Core.UnitsOfWork;
using Catalogs.Data;
using Catalogs.Data.UnitsOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogs.WebApi
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
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<CatalogsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                ));
            services.AddScoped<ICatalogUnit, CatalogUnit>();
            services.AddScoped<ICatalogItemUnit, CatalogItemUnit>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
