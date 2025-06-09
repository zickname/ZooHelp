using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class Height : ComparableValueObject
{
    public const int MAX_VAlUE = 100_000;

    public int Value { get; }

    //ef core
    private Height()
    {
    }

    private Height(int value) => Value = value;

    public static Result<Height> Create(int height)
    {
        if (height <= 0 || height > MAX_VAlUE)
            return Result.Failure<Height>($"Height must be between 1 and {MAX_VAlUE} grams.");

        var validHeight = new Height(height);

        return Result.Success(validHeight);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}