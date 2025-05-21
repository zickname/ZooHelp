using CSharpFunctionalExtensions;

using ZooHelp.Domain.SharedContext.ValueObjects;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public class PetType : ComparableValueObject
{
    public Name Name { get; }

    public Description Description { get; }

    private PetType(Name name, Description description)
    {
        Name = name;
        Description = description;
    }

    public static Result<PetType> Create(Name name, Description description)
    {
        PetType petType = new(name, description);

        return Result.Success<PetType>(petType);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Name;
        yield return Description;
    }
}