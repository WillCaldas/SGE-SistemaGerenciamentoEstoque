using SGE.CoreBusiness;

namespace SGE.UseCases.Interfaces
{
    public interface IValidateEnoughInventoriesForProducingUseCase
    {
        Task<bool> ExecuteAsync(Product prod, int quantity);
    }
}