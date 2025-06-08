using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.Shared.ValueObjects;

public sealed class Description : ComparableValueObject
{
    public const int MAX_LENGHTS = 500;

    public string Value { get; }

    //ef core
    private Description() { }

    private Description(string value) => Value = value;

    public static Result<Description> Create(string description)
    {
        if (string.IsNullOrWhiteSpace(description) || description.Length > MAX_LENGHTS)
            return Result.Failure<Description>("Description cannot be null or empty.");

        var validDescription = new Description(description);

        return Result.Success(validDescription);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}