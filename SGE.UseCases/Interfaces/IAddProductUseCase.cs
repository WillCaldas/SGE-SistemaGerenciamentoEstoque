using SGE.CoreBusiness;

namespace SGE.UseCases
{
    public interface IAddProductUseCase
    {
        Task ExecuteAsync(Product prod);
    }
}