using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;

using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public class Email : ComparableValueObject
{
    private const string REGEX = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    public string Value { get; }

    private Email(string email)
    {
        Value = email;
    }

    public static Result<Email> Create(string email)
    {
        Regex regex = new(REGEX);

        if (regex.IsMatch(email) == false)
            return Result.Failure<Email>($"Specified email address is invalid! : {email}");

        return Result.Success(new Email(email));
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}