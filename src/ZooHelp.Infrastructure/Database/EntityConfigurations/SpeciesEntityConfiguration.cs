using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ZooHelp.Domain.Shared.ValueObjects;
using ZooHelp.Domain.SpeciesContext.Entities;
using ZooHelp.Domain.SpeciesContext.ValueObjects;
using ZooHelp.Domain.SpeciesContext.ValueObjects.Ids;

namespace ZooHelp.Infrastructure.Database.EntityConfigurations;

public class SpeciesEntityConfiguration : IEntityTypeConfiguration<SpeciesEntity>
{
    public void Configure(EntityTypeBuilder<SpeciesEntity> builder)
    {
        builder.ToTable("species");
        
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasConversion(
                s => s.Value,
                value => SpeciesId.Create(value))
            .IsRequired();

        builder.ComplexProperty(s => s.Name, nb =>
        {
            nb.Property(n => n.Value)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(Name.MAX_LENGHTS);
        });

        builder.ComplexProperty(s => s.Title, tb =>
        {
            tb.Property(n => n.Value)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(Title.MAX_LENGHT);
        });

        builder.HasMany(s => s.Breeds)
            .WithOne()
            .HasForeignKey("species_id");
    }
}