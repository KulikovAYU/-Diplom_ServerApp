using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC_EMDB.Database.EntitiesConfiguration
{
  public  class TrainingDataTrainingConfig : IEntityTypeConfiguration<TrainingDataTraining>
    {
        public void Configure(EntityTypeBuilder<TrainingDataTraining> builder)
        {
            builder.HasKey(tdt => new { tdt.TrainingDataId, tdt.TrainingId });

            builder.HasOne(tdt => tdt.Training).
                WithMany(training => training.TrainingDataTrainings).
                HasForeignKey(tdt => tdt.TrainingId);//связь с  Coach

            builder.HasOne(tdt => tdt.TrainingData).
                WithMany(trainingdata => trainingdata.TrainingDataTrainings).
                HasForeignKey(ct => ct.TrainingDataId);//связь с  Training
        }
    }
}
