using app.ContractContext.ContractModule.Domain.Contract;
using app.ContractContext.ContractModule.Domain.Exception;
using app.ContractContext.ContractModule.Domain.View;
using app.SharedContext.CqrsModule.Domain.Model;
using app.SharedContext.CqrsModule.Domain.Contract;

namespace app.ContractContext.ContractModule.Application.Query.FindContract;

public class FindContractQueryHandler : IQueryHandler<FindContractQuery, ContractView>
{
    private readonly IContractRepository _contractRepository;

    public FindContractQueryHandler(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task<QueryResponse<ContractView>> Ask(FindContractQuery query)
    {
        var contract = await _contractRepository.ById(query.ContractId);
        if (null == contract) throw ContractNotFoundException.ById(query.ContractId);
        
        return new QueryResponse<ContractView>(
            new ContractView(contract),
            QueryMetadata.Unique
        );
    }
}