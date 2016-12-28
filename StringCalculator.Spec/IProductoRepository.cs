using System.Collections.Generic;

namespace StringCalculator.Spec
{
    public interface IProductoRepository
    {
        IEnumerable<Product> GetProducts();
    }
}