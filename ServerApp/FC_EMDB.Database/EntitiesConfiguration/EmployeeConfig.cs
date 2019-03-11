using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC_EMDB.Database.EntitiesConfiguration
{
  public  class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasBaseType<Human>();//имеется базовый тип человек
            
            
            builder.Property(emp => emp.Login).IsRequired().HasMaxLength(50);
            builder.Property(emp => emp.PasswordHash).IsRequired().HasMaxLength(50);
            builder.Property(emp => emp.Name).IsRequired().HasMaxLength(50);
            builder.Property(emp => emp.Family).IsRequired().HasMaxLength(50);
            builder.Property(emp => emp.LastName).IsRequired().HasMaxLength(50);
        }
    }
}
