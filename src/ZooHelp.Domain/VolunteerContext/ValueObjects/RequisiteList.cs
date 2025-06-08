using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public class RequisiteList
{
    private readonly List<Requisite> _requisites = [];

    public IReadOnlyList<Requisite> Requisites => _requisites;

    //ef core
    public RequisiteList() { }

    private RequisiteList(IEnumerable<Requisite> requisites)
    {
        _requisites = requisites.ToList();
    }

    public static RequisiteList Create(IEnumerable<Requisite> requisites)
    {
        return new RequisiteList(requisites);
    }

    public Result AddRequisite(Requisite requisite)
    {
        if (_requisites.Contains(requisite))
            return Result.Failure("Requisites already exists in the volunteer's list.");

        _requisites.Add(requisite);

        return Result.Success();
    }
}