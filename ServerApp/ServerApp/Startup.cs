using FC_EMDB.Database.DbContext;
using FC_EMDB.Database.Initializer;
using FC_EMDB.Database.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServerApp
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
            //объект сервиса создается при первом обращении к нему, все последующие запросы используют один и тот же ранее созданный объект сервиса
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<UnitOfWork>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("FC_EMDB.Migrations")));
            // services.AddDbContext<DataBaseFcContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("FC_EMDB.Migrations")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //инициализация наших сущностей
            DbInitializer.Seed(app);
        }
    }
}
