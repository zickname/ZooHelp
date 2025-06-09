using CSharpFunctionalExtensions;

using ZooHelp.Domain.Shared.ValueObjects;
using ZooHelp.Domain.SpeciesContext.ValueObjects;
using ZooHelp.Domain.SpeciesContext.ValueObjects.Ids;

namespace ZooHelp.Domain.SpeciesContext.Entities;

public class SpeciesEntity : Entity<SpeciesId>
{
    private List<BreedEntity> _breeds = [];

    public Name Name { get; private set; }

    public Title Title { get; private set; }

    public IReadOnlyList<BreedEntity> Breeds => _breeds;

    //ef core
    private SpeciesEntity()
    {
    }

    private SpeciesEntity(SpeciesId id, Name name, Title title) : base(id)
    {
        Name = name;
        Title = title;
    }

    public void AddBreed(BreedEntity breedEntity)
    {
        _breeds.Add(breedEntity);
    }

    public static Result<SpeciesEntity> Create(SpeciesId id, Name name, Title title)
    {
        return new SpeciesEntity(id, name, title);
    }
}