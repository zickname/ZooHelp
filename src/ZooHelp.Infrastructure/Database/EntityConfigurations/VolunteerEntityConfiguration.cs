using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ZooHelp.Domain.Shared.ValueObjects;
using ZooHelp.Domain.VolunteerContext.AgregateRoot;
using ZooHelp.Domain.VolunteerContext.ValueObjects.Ids;

namespace ZooHelp.Infrastructure.Database.EntityConfigurations;

public class VolunteerEntityConfiguration : IEntityTypeConfiguration<VolunteerEntity>
{
    public void Configure(EntityTypeBuilder<VolunteerEntity> builder)
    {
        builder.ToTable("volunteers");
        
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Id)
            .HasConversion(
                v => v.Value,
                value => VolunteerId.Create(value))
            .IsRequired();

        builder.ComplexProperty(v => v.Name, nb =>
        {
            nb.Property(n => n.Value)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(Name.MAX_LENGHTS);
        });

        builder.ComplexProperty(v => v.Email, eb =>
        {
            eb.Property(e => e.Value)
                .HasColumnName("email")
                .IsRequired();
        });

        builder.OwnsOne(
                v => v.Description,
                description =>
                {
                    description.Property(d => d.Value)
                        .HasColumnName("description")
                        .IsRequired();
                })
            .Navigation(v => v.Description)
            .IsRequired(false);

        builder.Property(v => v.ExperienceYears)
            .HasColumnName("experience_years")
            .IsRequired();

        builder.ComplexProperty(v => v.PhoneNumber, pb =>
        {
            pb.Property(p => p.Value)
                .HasColumnName("phone_number")
                .IsRequired();
        });

        builder.OwnsOne(v => v.SocialNetworks, nb =>
        {
            nb.OwnsMany(s => s.SocialNetworks, sb =>
            {
                sb.Property(v => v.Link)
                    .HasColumnName("link")
                    .IsRequired();

                sb.OwnsOne(v => v.Name, nb =>
                {
                    nb.Property(v => v.Value)
                        .HasColumnName("name")
                        .IsRequired()
                        .HasMaxLength(Name.MAX_LENGHTS);
                });
            });

            nb.ToJson();
        });

        builder.OwnsOne(v => v.RequisitesForHelp, vrb =>
        {
            vrb.OwnsMany(r => r.Requisites, rb =>
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

            vrb.ToJson();
        });

        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id");
    }
}