using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class Weight : ComparableValueObject
{
    public const int MAX_VAlUE = 500_000;

    public int Value { get; }

    private Weight() { }

    private Weight(int value) => Value = value;

    public static Result<Weight> Create(int grams)
    {
        if (grams <= 0 || grams > MAX_VAlUE)
            return Result.Failure<Weight>($"Weight must be between 1 and {MAX_VAlUE} grams.");

        return Result.Success(new Weight(grams));
    }

    public double ToKilograms() => Value / 1000.0;

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}