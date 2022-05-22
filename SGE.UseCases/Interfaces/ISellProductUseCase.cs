﻿using SGE.CoreBusiness;

namespace SGE.UseCases
{
    public interface ISellProductUseCase
    {
        Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, string doneBy);
    }
}