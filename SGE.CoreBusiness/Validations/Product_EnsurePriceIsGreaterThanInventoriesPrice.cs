using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.CoreBusiness.Validations
{
    internal class Product_EnsurePriceIsGreaterThanInventoriesPrice : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;
            if (product != null)
            {
                if (!product.ValidatePricing())
                {
                    return new ValidationResult($"Valor final do produto está abaixo do gasto em itens do Estoque - valor gasto do estoque R${product.TotalInventoryCost()}!",
                        new[] { validationContext.MemberName});
                }
            }

            return ValidationResult.Success;
        }
    }
}
