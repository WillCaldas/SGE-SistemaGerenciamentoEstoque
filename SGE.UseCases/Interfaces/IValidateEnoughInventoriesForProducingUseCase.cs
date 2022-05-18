using SGE.CoreBusiness;

namespace SGE.UseCases
{
    public interface IValidateEnoughInventoriesForProducingUseCase
    {
        Task<bool> ExecuteAsync(Product prod, int quantity);
    }
}