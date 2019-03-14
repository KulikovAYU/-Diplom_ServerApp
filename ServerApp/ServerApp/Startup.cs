using System;
using FC_EMDB.Database.DbContext;
using FC_EMDB.Database.Initializer;
using FC_EMDB.Database.UnitOfWork;
using FC_EMDB.Database.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddDbContext<DataBaseFcContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("FC_EMDB.Migrations")));
            
            services.AddTransient<IAbonementRepository, AbonementRepository>();
            services.AddTransient<ICoachRepository, CoachRepository>();
            services.AddTransient<ITrainingRepository, TrainingRepository>();
            services.AddTransient<ITrainingAbonementRepository, TrainingsAbonementsRepository>();
            services.AddTransient<IPreregistrationRepository, PreRegistrationRepository>();
            services.AddTransient<ICoachTrainingRepository, CoachTrainingRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IServiceProvider provider)
        {
            //сохраним ServiceProvider для того, чтобы получить доступ везде
           // IocContainer.Provider = (ServiceProvider)(provider);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
          //  app.ApplicationServices.GetRequiredService<IUnitOfWork>(); //получаем требуемый сервис

            app.UseMvc();
            //IUnitOfWork context1 =
            //    provider.GetRequiredService<IAbonementRepository>();
            //IUnitOfWork context =
            //    provider.GetRequiredService<IUnitOfWork>();
           
           // app.UseEFCoreInitializer(provider.GetRequiredService<IUnitOfWork>());
            //инициализация наших сущностей
            DbInitializer.Seed(provider.GetRequiredService<IUnitOfWork>());
        }
    }
}
