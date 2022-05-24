using SGE.CoreBusiness;

namespace SGE.UseCases.Interfaces
{
    public interface ISearchProductTransactionUseCase
    {
        Task<IEnumerable<ProductTransaction>> ExecuteAsync(string prodName, DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? transType);
    }
}