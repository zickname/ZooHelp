using CSharpFunctionalExtensions;

using ZooHelp.Domain.SharedContext.ValueObjects;
using ZooHelp.Domain.SpeciesContext.ValueObjects.Ids;

namespace ZooHelp.Domain.SpeciesContext.Entities;

public class Breed : Entity<BreedId>
{
    public Name Name { get; private set; }

    private Breed(BreedId id, Name name) : base(id)
    {
        Name = name;
    }

    public static Result<Breed> Create(BreedId id, Name name)
    {
        return Result.Success(new Breed(id, name));
    }
}