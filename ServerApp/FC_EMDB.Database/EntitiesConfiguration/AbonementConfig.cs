using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC_EMDB.Database.EntitiesConfiguration
{
    public class AbonementConfig : IEntityTypeConfiguration<Abonement>
    {

        public void Configure(EntityTypeBuilder<Abonement> builder)
        {
            //builder.HasKey(abonement => abonement.Id);

            //builder.HasOne(abonement => abonement.Client).WithOne(client => client.Abonement)
            //    .HasForeignKey<Abonement>(abonement => abonement.ClientId).IsRequired();

            //builder.HasOne(abonement => abonement.AbonementType).WithOne(abonementType => abonementType.Abonement)
            //    .HasForeignKey<Abonement>(abonement => abonement.AbonementTypeId).IsRequired();

            //builder.HasOne(abonement => abonement.AbonementStatus).WithMany(abonementstat => abonementstat.Abonements)
            //    .IsRequired();

            //builder.Property(abonement => abonement.Number).IsRequired();

        }
    }
}
