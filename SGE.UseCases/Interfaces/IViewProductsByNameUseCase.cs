using SGE.CoreBusiness;

namespace SGE.UseCases.Interfaces
{
    public interface IViewProductsByNameUseCase
    {
        Task<List<Product>> ExecuteAsync(string name = "");
    }
}