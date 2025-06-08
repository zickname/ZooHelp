using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.Shared.ValueObjects;

public class Name : ComparableValueObject
{
    public const int MAX_LENGHTS = 100;

    public string Value { get; }

    //ef core
    private Name()
    {
    }

    private Name(string value) => Value = value;

    public static Result<Name> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > MAX_LENGHTS)
            return Result.Failure<Name>("Name is too long");

        var validName = new Name(name);

        return Result.Success(validName);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}