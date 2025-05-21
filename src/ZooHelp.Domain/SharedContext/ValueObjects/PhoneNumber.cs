using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.SharedContext.ValueObjects;

public class PhoneNumber
{
    public string Value { get; }

    private PhoneNumber(string value) => Value = value;

    public static Result<PhoneNumber> Create(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return Result.Failure<PhoneNumber>("Phone cannot be null or empty.");

        var validPhone = new PhoneNumber(phoneNumber);

        return Result.Success(validPhone);
    }
}