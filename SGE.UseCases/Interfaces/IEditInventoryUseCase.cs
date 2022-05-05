using SGE.CoreBusiness;

namespace SGE.UseCases.Interfaces
{
    public interface IEditInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}