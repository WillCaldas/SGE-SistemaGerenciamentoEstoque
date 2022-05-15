using SGE.CoreBusiness;

namespace SGE.UseCases.Interfaces
{
    public interface IEditProductUseCase
    {
        Task ExecuteAsync(Product prod);
    }
}