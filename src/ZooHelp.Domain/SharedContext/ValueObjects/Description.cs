using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.SharedContext.ValueObjects;

public sealed class Description : ComparableValueObject
{
    private const int MAX_NAME_LENGHTS = 500;

    public string Value { get; }

    private Description(string value) => Value = value;

    public static Result<Description> Create(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Description>("Description cannot be null or empty.");

        var validDescription = new Description(description);

        return Result.Success(validDescription);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}