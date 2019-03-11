using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC_EMDB.Database.EntitiesConfiguration
{
    class PreRegistrationConfig : IEntityTypeConfiguration<PreRegistration>
    {
        public void Configure(EntityTypeBuilder<PreRegistration> builder)
        {
            builder.HasKey(pr => new {pr.TrainingId, pr.AbonementId});

            builder.HasOne(pr => pr.Abonement).
                    WithMany(abonement => abonement.PreRegistrations).
                    HasForeignKey(pr => pr.AbonementId);

            builder.HasOne(pr => pr.Training).
                    WithMany(training => training.PreRegistrations).
                    HasForeignKey(pr => pr.TrainingId);
        }
    }
}
