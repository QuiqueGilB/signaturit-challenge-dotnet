using app.ContractContext.ContractModule.Domain.ValueObject;
using app.SharedContext.PersistenceModule.Domain.Contract;

namespace app.ContractContext.ContractModule.Domain.Contract;

public interface IContractRepository: IRepository<Model.Contract, ContractId>
{
}
