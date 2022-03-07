using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Extensions;

namespace Application.Validators
{
    public class ProductValidator : Validator<Product>
    {
        public override void Validate(Product product)
        {
            if (!IsNull(product, "Nenhum produto foi informado"))
            {
                ValidateName(product);
                ValidatePrice(product);
            }

            SetValidity();
        }

        private void ValidatePrice(Product product)
        {
            if (product.Price <= default(double))
                ErrorMessages.Add("O preço do produto deve ser informado");
        }

        private void ValidateName(Product product)
        {
            if (product.Name.IsNull() || product.Name.IsEmpty())
                ErrorMessages.Add("Informe o Nome do produto.");
        }
    }
}
