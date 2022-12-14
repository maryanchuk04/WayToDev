using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WayToDev.Core.Entities;

namespace WayToDev.Db.Configurations;

public class TechStackConfiguration : IEntityTypeConfiguration<TechStack>
{
    public void Configure(EntityTypeBuilder<TechStack> builder)
    {
           
    }
}