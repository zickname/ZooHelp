using System.Text.RegularExpressions;

using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.Shared.ValueObjects;

public class PhoneNumber : ComparableValueObject
{
    private const string REGEX_PATTERN = "^\\+77[0-9]{9}$";

    public string Value { get; }

    //ef core
    private PhoneNumber() { }

    private PhoneNumber(string value) => Value = value;

    public static Result<PhoneNumber> Create(string phoneNumber)
    {
        if (Regex.IsMatch(phoneNumber, REGEX_PATTERN))
            return Result.Failure<PhoneNumber>("Invalid phone number");

        var validPhone = new PhoneNumber(phoneNumber);

        return Result.Success(validPhone);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}