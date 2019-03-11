

using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC_EMDB.Database.EntitiesConfiguration
{
    public class TrainingAbonementConfig : IEntityTypeConfiguration<TrainingAbonement>
    {
        public void Configure(EntityTypeBuilder<TrainingAbonement> builder)
        {
            builder.HasKey(ta => new { ta.TrainingId, ta.AbonementId });

            builder.HasOne(ta => ta.Abonement).
                 WithMany(abonement => abonement.TrainingAbonements).
                 HasForeignKey(ta => ta.AbonementId);

            builder.HasOne(ta => ta.Training).
                 WithMany(training => training.TrainingAbonements).
                 HasForeignKey(ta => ta.TrainingId);
        }
    }
}
