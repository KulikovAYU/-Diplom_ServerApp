using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC_EMDB.Database.EntitiesConfiguration
{
    public class VisitedTrainingClientConfig : IEntityTypeConfiguration<VisitedTrainingClient>
    {
        public void Configure(EntityTypeBuilder<VisitedTrainingClient> builder)
        {
            builder.HasKey(vtdt => new { vtdt.TrainingId, vtdt.ClientId });

            builder.HasOne(vtdt => vtdt.Training).
                WithMany(training => training.VisitedTrainingDataTrainings).
                HasForeignKey(tdt => tdt.TrainingId);//связь с  Training

            builder.HasOne(tdt => tdt.Client).
                WithMany(client => client.VisitedTrainingClients).
                HasForeignKey(ct => ct.ClientId);//связь с  Client
        }
    }
}
