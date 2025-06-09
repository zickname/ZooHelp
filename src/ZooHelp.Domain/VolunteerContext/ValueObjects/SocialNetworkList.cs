using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public class SocialNetworkList
{
    private readonly List<SocialNetwork> _socialNetworks = [];
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

    //ef core
    private SocialNetworkList() { }

    private SocialNetworkList(IEnumerable<SocialNetwork> socialNetworks)
    {
        _socialNetworks = socialNetworks.ToList();
    }

    public static SocialNetworkList Create(IEnumerable<SocialNetwork> socialNetworks)
    {
        return new SocialNetworkList(socialNetworks);
    }

    public Result AddSocialNetwork(SocialNetwork socialNetwork)
    {
        if (_socialNetworks.Contains(socialNetwork))
            return Result.Failure("SocialNetwork already exists.");

        _socialNetworks.Add(socialNetwork);

        return Result.Success();
    }
}