using CSharpFunctionalExtensions;

using ZooHelp.Domain.SharedContext.ValueObjects;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class Requisite : ComparableValueObject
{
    public Name Name { get; }

    public Description InfoOfTransfer { get; }

    private Requisite(Name name, Description infoOfTransfer)
    {
        Name = name;
        InfoOfTransfer = infoOfTransfer;
    }

    public static Result<Requisite> Create(Name name, Description infoOfTransfer)
    {
        var requisites = new Requisite(name, infoOfTransfer);

        return Result.Success<Requisite>(requisites);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Name.Value;
        yield return InfoOfTransfer;
    }
}