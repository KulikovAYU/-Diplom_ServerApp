using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC_EMDB.Database.EntitiesConfiguration
{
    public class ReplacedTrainingConfig : IEntityTypeConfiguration<ReplcedTraining>
    {
        public void Configure(EntityTypeBuilder<ReplcedTraining> builder)
        {
            builder.HasKey(rt => new { rt.TrainingDataId, rt.TrainingId });

            builder.HasOne(rt => rt.Training).
                WithMany(training => training.ReplcedTrainings).
                HasForeignKey(rt => rt.TrainingId);//связь с  ReplcedTraining

            builder.HasOne(rt => rt.TrainingData).
                WithMany(trainingdata => trainingdata.ReplacedTrainings).
                HasForeignKey(ct => ct.TrainingDataId);//связь с  TrainingData
        }
    }
}
