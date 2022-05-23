using SGE.CoreBusiness;

namespace SGE.UseCases.Interfaces
{
    public interface ISearchInventoryTransactionsUseCase
    {
        Task<IEnumerable<InventoryTransaction>> ExecuteAsync(string invName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transType);
    }
}