using CSharpFunctionalExtensions;

using ZooHelp.Domain.SharedContext.ValueObjects;
using ZooHelp.Domain.SpeciesContext.ValueObjects.Ids;

namespace ZooHelp.Domain.SpeciesContext.Entities;

public class Species : Entity<SpeciesId>
{
    private List<Breed> _breeds = [];

    public IReadOnlyList<Breed> Breeds => _breeds;

    public Name Name { get; private set; }

    public Title Title { get; private set; }

    private Species(SpeciesId id, Name name, Title title) : base(id)
    {
        Name = name;
        Title = title;
    }

    public void AddBreed(Breed breed)
    {
        _breeds.Add(breed);
    }

    public static Result<Species> Create(SpeciesId id, Name name, Title title)
    {
        return new Species(id, name, title);
    }
}

public sealed class Title
{
    public string Value { get; }
    private Title(string value) => Value = value;
}