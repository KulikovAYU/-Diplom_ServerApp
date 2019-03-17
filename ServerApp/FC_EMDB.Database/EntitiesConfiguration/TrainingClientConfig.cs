using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC_EMDB.Database.EntitiesConfiguration
{
    public class TrainingClientConfig : IEntityTypeConfiguration<TrainingClient>
    {
        public void Configure(EntityTypeBuilder<TrainingClient> builder)
        {
            builder.HasKey(tс => new { tс.TrainingId, tс.ClientId });

            builder.HasOne(tс => tс.Client).
                 WithMany(client => client.TrainingClients).
                 HasForeignKey(tс => tс.ClientId);

            builder.HasOne(tс => tс.Training).
                 WithMany(training => training.TrainingClients).
                 HasForeignKey(tс => tс.TrainingId);
        }
    }
}
