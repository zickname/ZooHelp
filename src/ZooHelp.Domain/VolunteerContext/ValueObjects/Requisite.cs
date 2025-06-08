using CSharpFunctionalExtensions;

using ZooHelp.Domain.Shared.ValueObjects;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class Requisite : ComparableValueObject
{
    public Name Name { get; }

    public Description Description { get; }

    //ef core
    private Requisite() { }

    private Requisite(Name name, Description description)
    {
        Name = name;
        Description = description;
    }

    public static Result<Requisite> Create(Name name, Description infoOfTransfer)
    {
        return Result.Success<Requisite>(new Requisite(name, infoOfTransfer));
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Name.Value;
        yield return Description;
    }
}