using CSharpFunctionalExtensions;

using ZooHelp.Domain.Shared.ValueObjects;

namespace ZooHelp.Domain.SpeciesContext.ValueObjects;

public sealed class Title : ComparableValueObject
{
    public const int MAX_LENGHT = 50;

    public string Value { get; }

    //ef core
    private Title()
    {
    }

    private Title(string value) => Value = value;

    public static Result<Title> Create(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > MAX_LENGHT)
        {
            return Result.Failure<Title>("Title is too long or empty");
        }

        var validTitle = new Title(title);

        return Result.Success(validTitle);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}