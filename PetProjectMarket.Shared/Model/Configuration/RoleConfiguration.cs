using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetProjectMarket.Shared.Model.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData
                (
                new IdentityRole
                {
                    Name="Admin",
                    NormalizedName="Admin"
                },
                new IdentityRole
                {
                    Name="VISITOR",
                    NormalizedName="Visitor"
                }
                );
        }
    }
}
