using CSharpFunctionalExtensions;

using ZooHelp.Domain.Shared.ValueObjects;
using ZooHelp.Domain.SpeciesContext.ValueObjects.Ids;

namespace ZooHelp.Domain.SpeciesContext.Entities;

public class BreedEntity : Entity<BreedId>
{
    //ef core
    private BreedEntity()
    {
    }

    public Name Name { get; private set; }

    private BreedEntity(BreedId id, Name name) : base(id)
    {
        Name = name;
    }

    public static Result<BreedEntity> Create(BreedId id, Name name)
    {
        return Result.Success(new BreedEntity(id, name));
    }
}