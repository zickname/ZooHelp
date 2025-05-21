using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class DateOfBirth : ComparableValueObject
{
    public DateTimeOffset Value { get; }

    private DateOfBirth(DateTimeOffset value) => Value = value;

    public static Result<DateOfBirth> Create(DateTimeOffset dateOfBirth)
    {
        if (dateOfBirth > DateTimeOffset.Now || dateOfBirth < DateTimeOffset.Now.AddYears(-30))
            return Result.Failure<DateOfBirth>("Incorrect date of birth");

        var validDateOfBirth = new DateOfBirth(dateOfBirth);

        return Result.Success(validDateOfBirth);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}