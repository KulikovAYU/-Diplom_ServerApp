using FC_EMDB.Database.EntitiesConfiguration;
using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace FC_EMDB.Database.DbContext
{
    public class DataBaseFcContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DataBaseFcContext(DbContextOptions<DataBaseFcContext> options) : base(options)
        {
            //Гарантирует, что база данных для контекста не существует. Если он не существует, никаких действий не предпринимается. Если он существует, то база данных удаляется.
            Database.EnsureCreated();
        }

        #region Свойства доступа к полям БД
        public DbSet<AbonementStatus> AbonementStatuses { get; set; }
        public DbSet<AbonementType> AbonementTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CoachTraining> CoachTrainings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PayTraining> PayTrainings { get; set; }
        public DbSet<ProgramType> ProgramTypes { get; set; }
        public DbSet<ReplcedTraining> ReplcedTrainings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<TrainingClient> TrainingClients { get; set; }
        public DbSet<TrainingData> TrainingDatas { get; set; }
        public DbSet<TrainingDataTraining> TrainingDataTrainings { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingLevel> TrainingLevels { get; set; }
        public DbSet<VisitedTrainingClient> VisitedTrainingClients { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //настройка конфигурации
            modelBuilder.ApplyConfiguration(new CoachTrainingConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new ReplacedTrainingConfig());
            modelBuilder.ApplyConfiguration(new TrainingClientConfig());
            modelBuilder.ApplyConfiguration(new TrainingDataTrainingConfig());
            modelBuilder.ApplyConfiguration(new PayTrainingConfig());
            modelBuilder.ApplyConfiguration(new VisitedTrainingClientConfig());
        }
    }
}
