using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class Weight : ComparableValueObject
{
    public float Value { get; }

    private Weight(float value) => Value = value;

    public static Result<Weight> Create(float weight)
    {
        if (weight <= 0)
            return Result.Failure<Weight>("Weight must be greater than 0");

        var validWeight = new Weight(weight);

        return Result.Success(validWeight);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}