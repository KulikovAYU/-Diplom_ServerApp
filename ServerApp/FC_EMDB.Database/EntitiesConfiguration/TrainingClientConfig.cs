

using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC_EMDB.Database.EntitiesConfiguration
{
    public class TrainingClientConfig : IEntityTypeConfiguration<TrainingClient>
    {
        public void Configure(EntityTypeBuilder<TrainingClient> builder)
        {
            builder.HasKey(ta => new { ta.TrainingId, ta.ClientId });

            builder.HasOne(ta => ta.Client).
                 WithMany(client => client.TrainingClients).
                 HasForeignKey(ta => ta.ClientId);

            builder.HasOne(ta => ta.Training).
                 WithMany(training => training.TrainingClients).
                 HasForeignKey(ta => ta.TrainingId);
        }
    }
}
