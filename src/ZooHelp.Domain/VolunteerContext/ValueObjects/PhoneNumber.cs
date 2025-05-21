using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class PhoneNumber : ComparableValueObject
{
    private PhoneNumber(string number)
    {
        Value = number;
    }

    public string Value { get; }

    public static Result<PhoneNumber> Create(string number)
    {
        if (string.IsNullOrEmpty(number))
            return Result.Failure<PhoneNumber>("Phone number cannot be empty");

        var phoneNumber = new PhoneNumber(number);

        return Result.Success(phoneNumber);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}