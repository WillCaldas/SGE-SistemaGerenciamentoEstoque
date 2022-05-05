using SGE.CoreBusiness;

namespace SGE.UseCases.Interfaces
{
    public interface IViewInventoryByIdUseCase
    {
        Task<Inventory?> ExecuteAsync(int inventoryId);
    }
}