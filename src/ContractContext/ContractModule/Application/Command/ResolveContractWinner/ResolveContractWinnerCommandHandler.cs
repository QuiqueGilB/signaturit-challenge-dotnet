using app.ContractContext.ContractModule.Domain.Contract;
using app.ContractContext.ContractModule.Domain.Exception;
using app.ContractContext.ContractModule.Domain.Model;
using app.ContractContext.ContractModule.Domain.Service;
using app.SharedContext.CqrsModule.Domain.Contract;
namespace app.ContractContext.ContractModule.Application.Command.ResolveContractWinner;

public sealed class ResolveContractWinnerCommandHandler : ICommandHandler<ResolveContractWinnerCommand>
{
    private readonly IContractRepository _contractRepository;
    private readonly ResolveSignatureScoresService _resolveSignatureScoresService;

    public ResolveContractWinnerCommandHandler(
        IContractRepository contractRepository,
        ResolveSignatureScoresService resolveSignatureScoresService
    )
    {
        _contractRepository = contractRepository;
        _resolveSignatureScoresService = resolveSignatureScoresService;
    }

    public async Task Handle(ResolveContractWinnerCommand command)
    {
        var contract = await _contractRepository.ById(command.ContractId);

        if (null == contract) throw ContractNotFoundException.ById(command.ContractId);
        if (contract.HasWinner) throw ContractAlreadyHasWinnerException.HasAlready(contract.Id);
        if (!contract.Participants.Any()) throw CanNotResolveContractWinnerException.Zero(contract.Id);

        contract.Participants.ForEach(participant =>
        {
            participant.Patch(score: _resolveSignatureScoresService.Accumulate(participant.Signatures));
        });

        var winners = Winners(contract.Participants);
        if (1 != winners.Count()) throw CanNotResolveContractWinnerException.Many(contract.Id);
        contract.Patch(winner: winners.First());
        
        await _contractRepository.Save(contract);
    }

    private IEnumerable<Participant> Winners(IEnumerable<Participant> participants)
    {
        var maxScore = participants.Select(participant => participant.Score?.Value).Max();
        return participants.Where(participant => participant.Score?.Value == maxScore);
    }
}
