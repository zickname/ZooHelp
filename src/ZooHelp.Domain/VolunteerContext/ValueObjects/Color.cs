using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class Color : ComparableValueObject
{
    public string Value { get; }

    private Color(string value) => Value = value;

    public static Result<Color> Create(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
            return Result.Failure<Color>("Color cannot be null or empty.");

        var validColor = new Color(color);

        return Result.Success(validColor);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}