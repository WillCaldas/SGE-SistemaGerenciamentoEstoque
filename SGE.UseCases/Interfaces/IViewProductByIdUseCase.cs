using SGE.CoreBusiness;

namespace SGE.UseCases.Interfaces
{
    public interface IViewProductByIdUseCase
    {
        Task<Product> ExecuteAsync(int prodId);
    }
}