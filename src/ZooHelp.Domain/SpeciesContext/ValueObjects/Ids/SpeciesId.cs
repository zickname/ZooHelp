using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.SpeciesContext.ValueObjects.Ids;

public sealed class SpeciesId : ComparableValueObject
{
    private SpeciesId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static SpeciesId NewSpeciesId() => new(Guid.CreateVersion7());

    public static SpeciesId Empty() => new(Guid.Empty);

    public static SpeciesId Create(Guid id) => new(id);

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}