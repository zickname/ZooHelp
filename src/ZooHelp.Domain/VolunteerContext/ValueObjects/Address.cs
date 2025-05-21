using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class Address : ComparableValueObject
{
    public string Country { get; }

    public string City { get; }

    public string Street { get; }

    public string House { get; }

    public string Apartment { get; }

    public string ZipCode { get; }

    private Address(
        string country,
        string city,
        string street,
        string house,
        string apartment,
        string zipCode
    )
    {
        Country = country;
        City = city;
        Street = street;
        House = house;
        Apartment = apartment;
        ZipCode = zipCode;
    }

    public static Result<Address> Create(
        string country,
        string city,
        string street,
        string house,
        string apartment,
        string zipCode
    )
    {
        if (string.IsNullOrWhiteSpace(country))
            return Result.Failure<Address>("Country cannot be empty.");

        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<Address>("City cannot be empty.");

        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<Address>("Street cannot be empty.");

        if (string.IsNullOrWhiteSpace(house))
            return Result.Failure<Address>("House cannot be empty.");

        if (string.IsNullOrWhiteSpace(apartment))
            return Result.Failure<Address>("Apartment cannot be empty.");

        var address = new Address(
            country,
            city,
            street,
            house,
            apartment,
            zipCode);

        return Result.Success(address);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Country;
        yield return City;
        yield return Street;
        yield return House;
        yield return Apartment;
        yield return ZipCode;
    }
}