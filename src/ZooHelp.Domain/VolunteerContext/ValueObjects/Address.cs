using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.VolunteerContext.ValueObjects;

public sealed class Address : ComparableValueObject
{
    public const int MAX_LENGTH = 50;

    public string Country { get; }

    public string City { get; }

    public string Street { get; }

    public string House { get; }

    public string? Apartment { get; }

    public string ZipCode { get; }

    private Address(
        string country,
        string city,
        string street,
        string house,
        string? apartment,
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
        
        if (country.Length > MAX_LENGTH)
            return Result.Failure<Address>($"Country cannot be longer than {MAX_LENGTH} characters.");

        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<Address>("City cannot be empty.");
        
        if (city.Length > MAX_LENGTH)
            return Result.Failure<Address>($"City cannot be longer than {MAX_LENGTH} characters.");

        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<Address>("Street cannot be empty.");
        
        if (street.Length > MAX_LENGTH)
            return Result.Failure<Address>($"Street cannot be longer than {MAX_LENGTH} characters.");

        if (string.IsNullOrWhiteSpace(house))
            return Result.Failure<Address>("House cannot be empty.");
        
        if (house.Length > MAX_LENGTH)
            return Result.Failure<Address>($"House cannot be longer than {MAX_LENGTH} characters.");

        if (!string.IsNullOrWhiteSpace(apartment) && apartment.Length > MAX_LENGTH)
            return Result.Failure<Address>($"Apartment cannot be longer than {MAX_LENGTH} characters.");

        if (string.IsNullOrWhiteSpace(zipCode))
            return Result.Failure<Address>("ZipCode cannot be empty.");
        
        if (zipCode.Length > MAX_LENGTH)
            return Result.Failure<Address>($"ZipCode cannot be longer than {MAX_LENGTH} characters.");

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