using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC_EMDB.Database.EntitiesConfiguration
{
    //настройка отношения многие ко многим
    public class CoachTrainingConfig : IEntityTypeConfiguration<CoachTraining>
    {
        public void Configure(EntityTypeBuilder<CoachTraining> builder)
        {
            builder.HasKey(ct => new {ct.CoachId, ct.TrainingId});

            builder.HasOne(ct => ct.Coach).
                    WithMany(coach => coach.CoachTrainings).
                    HasForeignKey(ct => ct.CoachId);//связь с  Coach

            builder.HasOne(ct => ct.Training).
                    WithMany(training => training.CoachTrainings).
                    HasForeignKey(ct => ct.TrainingId);//связь с  Training
        }
    }
}
