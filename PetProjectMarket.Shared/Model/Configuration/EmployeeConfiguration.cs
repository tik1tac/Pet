using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(x => x.Id)
    .ValueGeneratedOnAdd();

        builder.HasData
            (
            new EmployeeEntity
            {
                Name = "Admin",
                Family = "Admin",
                Surname = "admin",
                Address = "none",
                Phone = "none"
            },
             new EmployeeEntity
             {
                 Name = "Boss",
                 Family = "Boss",
                 Surname = "Boss",
                 Address = "none",
                 Phone = "none"
             },
             new EmployeeEntity
             {
                 Name = "Secretary",
                 Family = "Secretary",
                 Surname = "Secretary",
                 Address = "none",
                 Phone = "none"
             },
            new EmployeeEntity
            {
                Name = "Worker",
                Family = "Worker",
                Surname = "Worker",
                Address = "none",
                Phone = "none"
            }
            );
    }
}