using app.ContractContext.ContractModule.Domain.Contract;
using app.ContractContext.ContractModule.Domain.Exception;
using app.ContractContext.ContractModule.Domain.Model;
using app.ContractContext.ContractModule.Domain.Service;
using app.SharedContext.CqrsModule.Domain.Contract;

namespace app.ContractContext.ContractModule.Application.Command.ResolveSignatureForWin;

public sealed class ResolveSignatureForWinCommandHandler : ICommandHandler<ResolveSignatureForWinCommand>
{
    private readonly IContractRepository _contractRepository;
    private readonly ResolveNeedSignatureToWinService _needSignatureToWinService;

    public ResolveSignatureForWinCommandHandler(
        IContractRepository contractRepository,
        ResolveNeedSignatureToWinService needSignatureToWinService
    )
    {
        _contractRepository = contractRepository;
        _needSignatureToWinService = needSignatureToWinService;
    }

    public async Task Handle(ResolveSignatureForWinCommand command)
    {
        var contract = await _contractRepository.ById(command.ContractId);
        if (null == contract) throw ContractNotFoundException.ById(command.ContractId);

        var winner = contract.Winner;
        if (null == winner) throw ContractHasNotWinnerException.Unresolved(contract.Id);

        var participants = contract.Participants.Select<Participant, Participant>(participant =>
        {
            if (!participant.HasUnknownSignature) return participant;
            var signToWin = _needSignatureToWinService.NeedToWin(winner.Score!, participant.Signatures);
            participant.Patch(signaturesToWin: signToWin.ToList());
            return participant;
        }).ToList();

        contract.Patch(participants: participants);
        await _contractRepository.Save(contract);
    }
}
