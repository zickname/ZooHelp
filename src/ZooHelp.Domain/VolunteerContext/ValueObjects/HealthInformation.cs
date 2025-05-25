using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class HealthInformation : ComparableValueObject
{
    public string Value { get; }

    private HealthInformation(string value) => Value = value;

    public static Result<HealthInformation> Create(string healthInfornation)
    {
        if (string.IsNullOrWhiteSpace(healthInfornation))
            return Result.Failure<HealthInformation>("HealthInfo cannot be null or empty.");

        var validHealthInfo = new HealthInformation(healthInfornation);

        return Result.Success(validHealthInfo);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}