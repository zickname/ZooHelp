using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class HealthInformation : ComparableValueObject
{
    public const int MAX_LENGTH = 1000;

    public string Value { get; }

    //ef core
    private HealthInformation() { }

    private HealthInformation(string value) => Value = value;

    public static Result<HealthInformation> Create(string healthInfornation)
    {
        if (string.IsNullOrWhiteSpace(healthInfornation) || healthInfornation.Length > MAX_LENGTH)
            return Result.Failure<HealthInformation>("HealthInfo cannot be null or empty.");

        var validHealthInfo = new HealthInformation(healthInfornation);

        return Result.Success(validHealthInfo);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}