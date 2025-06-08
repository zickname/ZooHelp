using CSharpFunctionalExtensions;

using ZooHelp.Domain.Shared.ValueObjects;
using ZooHelp.Domain.VolunteerContext.Entities;
using ZooHelp.Domain.VolunteerContext.Enums;
using ZooHelp.Domain.VolunteerContext.ValueObjects;
using ZooHelp.Domain.VolunteerContext.ValueObjects.Ids;

using PhoneNumber = ZooHelp.Domain.Shared.ValueObjects.PhoneNumber;

namespace ZooHelp.Domain.VolunteerContext.AgregateRoot;

public class VolunteerEntity : Entity<VolunteerId>
{
    private readonly List<PetEntity> _pets = [];

    public Name Name { get; private set; }

    public Email Email { get; private set; }

    public Description? Description { get; private set; }

    public int ExperienceYears { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }

    public SocialNetworkList SocialNetworks { get; private set; }

    public RequisiteList RequisitesForHelp { get; private set; }

    public IReadOnlyList<PetEntity> Pets => _pets;

    public IReadOnlyList<PetEntity> PetsNeedsHelp => GetPetsNeedsHelp();

    public IReadOnlyList<PetEntity> PetsLookingForHome => GetPetsLookingForHome();

    public IReadOnlyList<PetEntity> PetsFoundHome => GetPetsFoundHome();

    //ef core
    private VolunteerEntity() { }

    private VolunteerEntity(
        VolunteerId id,
        Name name,
        Email email,
        Description description,
        int experienceYears,
        PhoneNumber phoneNumber)
    {
        Id = id;
        Name = name;
        Email = email;
        Description = description;
        ExperienceYears = experienceYears;
        PhoneNumber = phoneNumber;
    }

    public static Result<VolunteerEntity> Create(
        VolunteerId id,
        Name name,
        Email email,
        Description description,
        int experienceYears,
        PhoneNumber phoneNumber)
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
                phoneNumber);

        return Result.Success(volunteerEntity);
    }

    public void UpdateRequisitesForHelp(IEnumerable<Requisite> requisites)
    {
        RequisitesForHelp = RequisiteList.Create(requisites);
    }

    public void UpdateSocialNetworkList(IEnumerable<SocialNetwork> socialNetworkList)
    {
        SocialNetworks = SocialNetworkList.Create(socialNetworkList);
    }

    public Result AddPet(PetEntity pet)
    {
        if (_pets.Contains(pet))
            return Result.Failure("Pet already exists in the volunteer's list.");

        _pets.Add(pet);

        return Result.Success();
    }

    private IReadOnlyList<PetEntity> GetPetsNeedsHelp()
    {
        return _pets
            .Where(p => p.HelpStatus is HelpStatus.NeedHelp)
            .ToList();
    }

    private IReadOnlyList<PetEntity> GetPetsLookingForHome()
    {
        return _pets
            .Where(p => p.HelpStatus is HelpStatus.LookingHome)
            .ToList();
    }

    private IReadOnlyList<PetEntity> GetPetsFoundHome()
    {
        return _pets
            .Where(p => p.HelpStatus is HelpStatus.FoundHome)
            .ToList();
    }
}