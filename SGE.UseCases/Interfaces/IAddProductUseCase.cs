using SGE.CoreBusiness;

namespace SGE.UseCases.Interfaces
{
    public interface IAddProductUseCase
    {
        Task ExecuteAsync(Product prod);
    }
}