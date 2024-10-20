using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgocThuy_Lab4_3.Models
{
    public  interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(string productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(string productId);
    }
}
