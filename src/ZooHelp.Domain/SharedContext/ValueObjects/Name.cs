using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.SharedContext.ValueObjects;

public class Name : ComparableValueObject
{
    private const int MAX_NAME_LENGHTS = 100;

    public string Value { get; }

    private Name(string value) => Value = value;

    public static Result<Name> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > MAX_NAME_LENGHTS)
            return Result.Failure<Name>("Name is too long");

        var validName = new Name(name);

        return Result.Success(validName);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}