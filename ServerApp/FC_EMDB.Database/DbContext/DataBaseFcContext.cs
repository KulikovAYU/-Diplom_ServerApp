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
        public virtual DbSet<Abonement> Abonements { get; set; }
        public virtual DbSet<AbonementStatus> AbonementStatuses { get; set; }
        public virtual DbSet<AbonementType> AbonementTypes { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<CoachTraining> CoachTrainings { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Gym> Gyms { get; set; }
        //public virtual DbSet<Human> Humans { get; set; }
        public virtual DbSet<PreRegistration> PreRegistrations { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<TrainingAbonement> TrainingAbonements { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new AbonementConfig());
            modelBuilder.ApplyConfiguration(new CoachTrainingConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new CoachTrainingConfig());
            modelBuilder.ApplyConfiguration(new PreRegistrationConfig());
            modelBuilder.ApplyConfiguration(new TrainingAbonementConfig());
        }

        
    }
}
