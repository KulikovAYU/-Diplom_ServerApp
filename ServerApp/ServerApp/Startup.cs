using System;
using FC_EMDB.Database.DbContext;
using FC_EMDB.Database.UnitOfWork;
using FC_EMDB.Database.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServerApp.CustomMiddleware;

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

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IAbonementStatusRepository, AbonementStatusRepository>();
            services.AddTransient<IAbonementTypeRepository, AbonementTypeRepository>();
            services.AddTransient<ITrainingClientRepository, TrainingClientRepository>();
            services.AddTransient<ITrainingDataRepository, TrainingDataRepository>();
            services.AddTransient<ITrainingRepository, TrainingRepository>();
            services.AddTransient<IGymRepository, GymRepository>();
            services.AddTransient<ICoachTrainingRepository, CoachTrainingRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IReplacedTrainingRepository, ReplacedTrainingRepository>();
            services.AddTransient<ITrainingLevelRepository, TrainingLevelRepository>();
            services.AddTransient<IProgramTypeRepository, ProgramTypeRepository>();
            services.AddTransient<IVisitedTrainingClientRepository, VisitedTrainingClientRepository>();
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
            else
            {
                app.UseHsts();
            }

            app.UseEFCoreInitializer();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
