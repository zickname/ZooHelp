using CSharpFunctionalExtensions;

using ZooHelp.Domain.SharedContext.ValueObjects;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class SocialNetwork : ComparableValueObject
{
    public string Link { get; }

    public Name Name { get; }

    private SocialNetwork(string link, Name name)
    {
        Link = link;
        Name = name;
    }

    public static Result<SocialNetwork> Create(string link, Name name)
    {
        if (string.IsNullOrWhiteSpace(link))
            return Result.Failure<SocialNetwork>("Link cannot be null or empty.");

        var validSocialNetwork = new SocialNetwork(link, name);

        return Result.Success(validSocialNetwork);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Link;
        yield return Name;
    }
}