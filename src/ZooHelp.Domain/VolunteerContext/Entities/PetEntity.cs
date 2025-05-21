using CSharpFunctionalExtensions;

using ZooHelp.Domain.SharedContext.ValueObjects;
using ZooHelp.Domain.SpeciesContext.Entities;
using ZooHelp.Domain.VolunteerContext.ValueObjects;
using ZooHelp.Domain.VolunteerContext.ValueObjects.Ids;

using Color = ZooHelp.Domain.VolunteerContext.ValueObjects.Color;
using PhoneNumber = ZooHelp.Domain.VolunteerContext.ValueObjects.PhoneNumber;

namespace ZooHelp.Domain.VolunteerContext.Entities;

public sealed class PetEntity : Entity<PetId>
{
    public Name Name { get; private set; }

    public Breed Breed { get; private set; }

    public Description Description { get; private set; }

    public Color Color { get; private set; }

    public Weight Weight { get; private set; }

    public Height Height { get; private set; }

    public HealthInformation HealthInformation { get; private set; }

    public Address Address { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }

    public bool IsCastrated { get; private set; }

    public DateOfBirth BirthDate { get; private set; }

    public bool IsVaccinated { get; private set; }

    public HelpStatus HelpStatus { get; private set; }

    public Requisite Requisites { get; private set; }

    public DateTimeOffset CreatedAt = DateTimeOffset.Now;

    private PetEntity(
        PetId id,
        Name name,
        Breed breed,
        Description description,
        Color color,
        Height height,
        Weight weight,
        HealthInformation healthInformation,
        Address address,
        PhoneNumber phoneNumber,
        bool isCastrated,
        DateOfBirth birthDate,
        bool isVaccinated,
        HelpStatus helpStatus,
        Requisite requisites) : base(id)
    {
        Name = name;
        Breed = breed;
        Description = description;
        Color = color;
        Height = height;
        Weight = weight;
        HealthInformation = healthInformation;
        Address = address;
        PhoneNumber = phoneNumber;
        IsCastrated = isCastrated;
        BirthDate = birthDate;
        IsVaccinated = isVaccinated;
        HelpStatus = helpStatus;
        Requisites = requisites;
    }

    public static Result<PetEntity> Create(
        PetId id,
        Name name,
        Breed breed,
        Description description,
        Color color,
        Height height,
        Weight weight,
        HealthInformation healthInformation,
        Address address,
        PhoneNumber phone,
        bool isCastrated,
        DateOfBirth birthDate,
        bool isVaccinated,
        HelpStatus status,
        Requisite requisites)
    {
        return Result.Success(
            new PetEntity(
                id,
                name,
                breed,
                description,
                color,
                height,
                weight,
                healthInformation,
                address,
                phone,
                isCastrated,
                birthDate,
                isVaccinated,
                status,
                requisites));
    }
}