using SGE.CoreBusiness;

namespace SGE.UseCases.Interfaces
{
    public interface IProduceProductUseCase
    {
        Task ExecuteAsync(string prodOrder, Product product, int quantity, string doneBy);
    }
}

