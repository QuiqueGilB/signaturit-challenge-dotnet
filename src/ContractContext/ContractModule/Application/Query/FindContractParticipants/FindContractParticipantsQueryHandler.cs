using app.ContractContext.ContractModule.Domain.Contract;
using app.ContractContext.ContractModule.Domain.Exception;
using app.ContractContext.ContractModule.Domain.View;
using app.SharedContext.CqrsModule.Domain.Contract;
using app.SharedContext.CqrsModule.Domain.Model;

namespace app.ContractContext.ContractModule.Application.Query.FindContractParticipants;

public class FindContractParticipantsQueryHandler
    : IQueryHandler<FindContractParticipantsQuery, IEnumerable<ParticipantView>>
{
    private readonly IContractRepository _contractRepository;

    public FindContractParticipantsQueryHandler(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task<QueryResponse<IEnumerable<ParticipantView>>> Ask(FindContractParticipantsQuery query)
    {
        var contract = await _contractRepository.ById(query.ContractId);
        if (null == contract) throw ContractNotFoundException.ById(query.ContractId);

        var participantsView = contract.Participants
            .Select(participant => new ParticipantView(participant.Id, participant.Signatures));

        return new QueryResponse<IEnumerable<ParticipantView>>(
            participantsView,
            new QueryMetadata(participantsView.Count(), participantsView.Count(), 0, 0)
        );
    }
}
