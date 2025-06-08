using CSharpFunctionalExtensions;

using ZooHelp.Domain.Shared.ValueObjects;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class SocialNetwork : ComparableValueObject
{
    public const int MAX_LENGTH = 250;

    public string Link { get; }

    public Name Name { get; }

    //ef core
    private SocialNetwork() { }

    private SocialNetwork(string link, Name name)
    {
        Link = link;
        Name = name;
    }

    public static Result<SocialNetwork> Create(string link, Name name)
    {
        if (string.IsNullOrWhiteSpace(link) || link.Length > MAX_LENGTH)
            return Result.Failure<SocialNetwork>("Social network link is too long");

        var validSocialNetwork = new SocialNetwork(link, name);

        return Result.Success(validSocialNetwork);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Link;
        yield return Name;
    }
}