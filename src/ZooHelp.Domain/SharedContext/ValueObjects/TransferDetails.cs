using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.SharedContext.ValueObjects;

public sealed class TransferDetails
{
    public string Name { get; }

    public string Description { get; }

    private TransferDetails(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static Result<TransferDetails> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<TransferDetails>("Name of TransferDetails cannot be null or empty.");

        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<TransferDetails>("Description of TransferDetails cannot be null or empty.");

        var validTransferDetails = new TransferDetails(name, description);

        return Result.Success(validTransferDetails);
    }
}