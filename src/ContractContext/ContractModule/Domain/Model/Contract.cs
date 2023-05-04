using app.ContractContext.ContractModule.Domain.Exception;
using app.ContractContext.ContractModule.Domain.ValueObject;
using app.SharedContext.EventSourcingModule.Domain.Event;
using app.SharedContext.SharedModule.Domain.Model;
using app.SharedContext.SharedModule.Domain.ValueObject;

namespace app.ContractContext.ContractModule.Domain.Model;

public class Contract : AggregateRoot<ContractId>
{
    private const int MinParticipantsRequired = 2;
    
    public List<Participant> Participants { get; private set; }
    public Participant? Winner { get; private set; }
    public bool HasWinner => null != Winner;

    public Contract(ContractId id, Participant[] participants) : base(id)
    {
        Winner = null;
        Participants = participants.ToList();
        //     $this->record(new ContractCreatedEvent($this));
    }

    public void Put(Participant? winner, List<Participant> participants)
    {
         var isANewWinner = winner?.Id != Winner?.Id;
        DoUpdate(winner, participants);
//         $this->record(new ContractUpdatedEvent($this));
//         $isANewWinner && $this->record(new ContractWonEvent($this));
    }

    public void Patch(Participant? winner = null, List<Participant>? participants = null)
    {
        Put(winner ?? Winner, participants ?? Participants);
    }

    private void DoUpdate(Participant? winner, List<Participant> participants)
    {
        ValidateNewWinner(winner);
        ValidateParticipants(participants);

        Winner = winner;
        Participants = participants;
        UpdatedAt = DateTime.Now;
    }

    private void ValidateNewWinner(Participant? winner)
    {
        if (null == Winner || Winner.Equals(winner))
        {
            return;
        }

        throw ContractAlreadyHasWinnerException.HasAlready(Id);
    }

    private void ValidateParticipants(IEnumerable<Participant> participants)
    {
        if (participants.Count() < MinParticipantsRequired)
        {
            throw MinContractParticipantsException.ById(Id, MinParticipantsRequired);
        }
    }
}
