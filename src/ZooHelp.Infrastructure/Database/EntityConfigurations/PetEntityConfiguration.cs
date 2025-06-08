using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ZooHelp.Domain.Shared.ValueObjects;
using ZooHelp.Domain.VolunteerContext.Entities;
using ZooHelp.Domain.VolunteerContext.ValueObjects;
using ZooHelp.Domain.VolunteerContext.ValueObjects.Ids;

namespace ZooHelp.Infrastructure.Database.EntityConfigurations;

public class PetEntityConfiguration : IEntityTypeConfiguration<PetEntity>
{
    public void Configure(EntityTypeBuilder<PetEntity> builder)
    {
        builder.ToTable("pets");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                p => p.Value,
                value => PetId.Create(value))
            .IsRequired();

        builder.ComplexProperty(p => p.Name, nb =>
        {
            nb.Property(n => n.Value)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(Name.MAX_LENGHTS);
        });

        builder.ComplexProperty(p => p.Description, db =>
        {
            db.Property(d => d.Value)
                .HasColumnName("description")
                .IsRequired()
                .HasMaxLength(Description.MAX_LENGHTS);
        });

        builder.ComplexProperty(p => p.Color, cb =>
        {
            cb.Property(c => c.Value)
                .HasColumnName("color")
                .IsRequired()
                .HasMaxLength(Color.MAX_LENGHTS);
        });

        builder.ComplexProperty(p => p.Weight, wb =>
        {
            wb.Property(w => w.Value)
                .HasColumnName("weight")
                .IsRequired()
                .HasMaxLength(Weight.MAX_VAlUE);
        });

        builder.ComplexProperty(p => p.Height, nb =>
        {
            nb.Property(h => h.Value)
                .HasColumnName("height")
                .IsRequired()
                .HasMaxLength(Height.MAX_VAlUE);
        });

        builder.ComplexProperty(p => p.HealthInformation, nb =>
        {
            nb.Property(n => n.Value)
                .HasColumnName("health_information")
                .IsRequired()
                .HasMaxLength(HealthInformation.MAX_LENGTH);
        });

        builder.ComplexProperty(p => p.Address, b =>
        {
            b.Property(v => v.Country)
                .HasColumnName("country")
                .IsRequired();

            b.Property(v => v.City)
                .HasColumnName("city")
                .IsRequired();

            b.Property(v => v.Street)
                .HasColumnName("street")
                .IsRequired();

            b.Property(v => v.House)
                .HasColumnName("house")
                .IsRequired();

            b.Property(v => v.Apartment)
                .HasColumnName("apartment")
                .IsRequired(false);

            b.Property(z => z.ZipCode)
                .HasColumnName("zip_code")
                .IsRequired();
        });

        builder.ComplexProperty(p => p.PhoneNumber, nb =>
        {
            nb.Property(n => n.Value)
                .HasColumnName("phone")
                .IsRequired()
                .HasMaxLength(15);
        });

        builder.Property(p => p.IsCastrated)
            .HasColumnName("is_castrated")
            .IsRequired();

        builder.ComplexProperty(p => p.BirthDate, b =>
        {
            b.Property(a => a.Value)
                .HasColumnName("birth_date")
                .IsRequired();
        });

        builder.Property(p => p.IsVaccinated)
            .HasColumnName("is_vaccinated")
            .IsRequired();

        builder.Property(p => p.HelpStatus)
            .HasColumnName("help_status")
            .IsRequired()
            .HasConversion<int>();

        builder.OwnsOne(p => p.RequisitesForHelp, prb =>
        {
            prb.OwnsMany(r => r.Requisites, rb =>
            {
                rb.OwnsOne(v => v.Name, nb =>
                {
                    nb.Property(n => n.Value)
                        .HasColumnName("name")
                        .IsRequired()
                        .HasMaxLength(Name.MAX_LENGHTS);
                });

                rb.OwnsOne(v => v.Description, db =>
                {
                    db.Property(d => d.Value)
                        .HasColumnName("description")
                        .IsRequired()
                        .HasMaxLength(Description.MAX_LENGHTS);
                });
            });

            prb.ToJson();
        });

        builder.Property(p => p.CreatedAt)
            .IsRequired();
    }
}