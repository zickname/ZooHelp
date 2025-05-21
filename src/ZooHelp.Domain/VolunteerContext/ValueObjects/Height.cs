using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class Height : ComparableValueObject
{
    public float Value { get; }

    private Height(float value) => Value = value;

    public static Result<Height> Create(float height)
    {
        if (height <= 0)
            return Result.Failure<Height>("Height must be greater than 0");

        var validHeight = new Height(height);

        return Result.Success(validHeight);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}