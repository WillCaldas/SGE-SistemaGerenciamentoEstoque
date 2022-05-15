namespace SGE.UseCases.Interfaces
{
    public interface IDeleteProductUseCase
    {
        Task ExecuteAsync(int prodId);
    }
}