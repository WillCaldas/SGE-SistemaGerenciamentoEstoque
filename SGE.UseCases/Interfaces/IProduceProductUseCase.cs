using SGE.CoreBusiness;

namespace SGE.UseCases
{
    public interface IProduceProductUseCase
    {
        Task ExecuteAsync(string prodOrder, Product product, int quantity, double price, string doneBy);
    }
}