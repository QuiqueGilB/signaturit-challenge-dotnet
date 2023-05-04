using app.ContractContext.ContractModule.Domain.Contract;
using app.ContractContext.ContractModule.Domain.Model;
using app.SharedContext.CqrsModule.Domain.Contract;

namespace app.ContractContext.ContractModule.Application.Command.CreateContract;

public sealed class CreateContractCommandHandler : ICommandHandler<CreateContractCommand>
{
    private readonly IContractRepository _contractRepository;

    public CreateContractCommandHandler(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task Handle(CreateContractCommand command)
    {
        var participants = command.Participants.Select(
            participantData => new Participant(participantData.ParticipantId, participantData.Signatures)
        ).ToArray();
        
        var contract = new Contract(command.ContractId, participants);
        await _contractRepository.Save(contract);
    }
}
