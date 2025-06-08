using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class Color : ComparableValueObject
{
    public const int MAX_LENGHTS = 15;
    
    public string Value { get; }

    //ef core
    private Color()
    {
    }

    private Color(string value) => Value = value;

    public static Result<Color> Create(string color)
    {
        if (string.IsNullOrWhiteSpace(color) || color.Length > MAX_LENGHTS)
            return Result.Failure<Color>("Color cannot be null or empty.");

        var validColor = new Color(color);

        return Result.Success(validColor);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}