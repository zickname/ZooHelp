using CSharpFunctionalExtensions;

using ZooHelp.Domain.SharedContext.ValueObjects;
using ZooHelp.Domain.VolunteerContext.Entities;
using ZooHelp.Domain.VolunteerContext.ValueObjects;
using ZooHelp.Domain.VolunteerContext.ValueObjects.Ids;

using PhoneNumber = ZooHelp.Domain.VolunteerContext.ValueObjects.PhoneNumber;

namespace ZooHelp.Domain.VolunteerContext.AgregateRoot;

public class VolunteerEntity : Entity<VolunteerId>
{
    private readonly List<SocialNetwork> _socialNetworks = [];

    private readonly List<PetEntity> _allPets = [];

    public VolunteerId Id { get; private set; }

    public Name Name { get; private set; }

    public Email Email { get; private set; }

    public Description Description { get; private set; }

    public int ExperienceYears { get; private set; }

    public PhoneNumber PhoneNumber { get; }

    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

    public Requisite Requisite { get; }

    public IReadOnlyList<PetEntity> AllPets => _allPets;

    public IReadOnlyList<PetEntity> PetsNeedsHelp => GetPetsNeedsHelp();

    public IReadOnlyList<PetEntity> PetsLookingForHome => GetPetsLookingForHome();

    public IReadOnlyList<PetEntity> PetsFoundHome => GetPetsFoundHome();

    private VolunteerEntity(
        VolunteerId id,
        Name name,
        Email email,
        Description description,
        int experienceYears,
        PhoneNumber phoneNumber,
        Requisite requisite)
    {
        Id = id;
        Name = name;
        Email = email;
        Description = description;
        ExperienceYears = experienceYears;
        PhoneNumber = phoneNumber;
        Requisite = requisite;
    }

    public static Result<VolunteerEntity> Create(
        VolunteerId id,
        Name name,
        Email email,
        Description description,
        int experienceYears,
        PhoneNumber phoneNumber,
        Requisite helpDetails)
    {
        if (experienceYears < 0)
            return Result.Failure<VolunteerEntity>("Experience years cannot be negative.");

        VolunteerEntity volunteerEntity =
            new(
                id,
                name,
                email,
                description,
                experienceYears,
                phoneNumber,
                helpDetails);

        return Result.Success(volunteerEntity);
    }

    public Result AddSocialNetwork(SocialNetwork socialNetwork)
    {
        if (_socialNetworks.Contains(socialNetwork))
            return Result.Failure("Social network already exists in the volunteer's list.");

        _socialNetworks.Add(socialNetwork);

        return Result.Success();
    }

    public Result AddPet(PetEntity pet)
    {
        if (_allPets.Contains(pet))
            return Result.Failure("Pet already exists in the volunteer's list.");

        _allPets.Add(pet);

        return Result.Success();
    }

    private IReadOnlyList<PetEntity> GetPetsNeedsHelp()
    {
        return _allPets
            .Where(p => p.HelpStatus is HelpStatus.NeedHelp)
            .ToList();
    }

    private IReadOnlyList<PetEntity> GetPetsLookingForHome()
    {
        return _allPets
            .Where(p => p.HelpStatus is HelpStatus.LookingHome)
            .ToList();
    }

    private IReadOnlyList<PetEntity> GetPetsFoundHome()
    {
        return _allPets
            .Where(p => p.HelpStatus is HelpStatus.FoundHome)
            .ToList();
    }
}