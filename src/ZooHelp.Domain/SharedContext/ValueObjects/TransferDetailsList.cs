using CSharpFunctionalExtensions;

namespace ZooHelp.Domain.SharedContext.ValueObjects;

public sealed class TransferDetailsList
{
    private readonly List<TransferDetails> _transferDetails;

    public IReadOnlyList<TransferDetails> TransferDetails => _transferDetails;

    private TransferDetailsList(IEnumerable<TransferDetails> transferDetails)
    {
        _transferDetails = transferDetails.ToList();
    }

    public static Result<TransferDetailsList> Create(IEnumerable<TransferDetails> transferDetails)
    {
        return new TransferDetailsList(transferDetails);
    }
}