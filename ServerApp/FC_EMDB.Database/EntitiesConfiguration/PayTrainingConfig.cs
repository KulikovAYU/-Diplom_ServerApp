using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC_EMDB.Database.EntitiesConfiguration
{
    public class PayTrainingConfig : IEntityTypeConfiguration<PayTraining>
    {
        public void Configure(EntityTypeBuilder<PayTraining> builder)
        {
            builder.HasBaseType<TrainingData>();//имеется базовый тип человек

            builder.Property(pt => pt.PlacesCount).IsRequired();
        }
    }
}
