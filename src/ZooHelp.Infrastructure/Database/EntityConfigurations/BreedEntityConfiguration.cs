using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ZooHelp.Domain.Shared.ValueObjects;
using ZooHelp.Domain.SpeciesContext.Entities;
using ZooHelp.Domain.SpeciesContext.ValueObjects.Ids;

namespace ZooHelp.Infrastructure.Database.EntityConfigurations;

public class BreedEntityConfiguration : IEntityTypeConfiguration<BreedEntity>
{
    public void Configure(EntityTypeBuilder<BreedEntity> builder)
    {
        builder.ToTable("breeds");

        builder.HasKey(b => b.Id);

        builder.Property<BreedId>(b => b.Id)
            .HasConversion(
                b => b.Value,
                value => BreedId.Create(value))
            .IsRequired();

        builder.ComplexProperty(b => b.Name, nb =>
        {
            nb.Property(n => n.Value)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(Name.MAX_LENGHTS);
        });
    }
}