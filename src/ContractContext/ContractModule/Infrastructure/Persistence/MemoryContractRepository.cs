using app.ContractContext.ContractModule.Domain.Contract;
using app.ContractContext.ContractModule.Domain.Model;
using app.ContractContext.ContractModule.Domain.ValueObject;
using app.SharedContext.PersistenceModule.Domain.Service;

namespace app.ContractContext.ContractModule.Infrastructure.Persistence;

public class MemoryContractRepository : MemoryRepository<Contract, ContractId>, IContractRepository
{
}
