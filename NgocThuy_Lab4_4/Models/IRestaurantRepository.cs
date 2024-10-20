using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgocThuy_Lab4_4.Models
{
    public interface IRestaurantRepository 
    {
        List<Catogory> GetAllCategories();
        List<Product> GetProductsByCategory(string categoryId);
        void AddCategory(Catogory category);
        void UpdateCategory(Catogory category);
        void DeleteCategory(string categoryId);
        void AddProduct(string categoryId, Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(string productId, string categoryId);
        Product GetProductById(string productId);




    }
}
