using NgocThuy_Lab4_3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Xml.Linq;

namespace NgocThuy_Lab4_3
{
    public class ProductRepository : IProductRepository
    {
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "product.xml");
        public List<Product> GetAllProducts()
        {
            XDocument doc = XDocument.Load(filePath);
            var products = doc.Descendants("Product")
                .Select(p => new Product
                {
                    ProductId = p.Element("ProductId").Value,
                    ProductName = p.Element("ProductName").Value,
                    Unit = p.Element("Unit").Value,
                    Price = decimal.Parse(p.Element("Price").Value)
                }).ToList();

            return products;
        }

        // Lấy sản phẩm theo Id
        public Product GetProductById(string productId)
        {
            var products = GetAllProducts();
            return products.FirstOrDefault(p => p.ProductId == productId);
        }

        // Thêm sản phẩm
        public void AddProduct(Product product)
        {
            XDocument doc = XDocument.Load(filePath);
            XElement newProduct = new XElement("Product",
                new XElement("ProductId", product.ProductId),
                new XElement("ProductName", product.ProductName),
                new XElement("Unit", product.Unit),
                new XElement("Price", product.Price)
            );
            doc.Element("Products").Add(newProduct);
            doc.Save(filePath);
        }

        // Cập nhật sản phẩm
        public void UpdateProduct(Product product)
        {
            XDocument doc = XDocument.Load(filePath);
            var existingProduct = doc.Descendants("Product")
                .FirstOrDefault(p => p.Element("ProductId").Value == product.ProductId);

            if (existingProduct != null)
            {
                existingProduct.Element("ProductName").Value = product.ProductName;
                existingProduct.Element("Unit").Value = product.Unit;
                existingProduct.Element("Price").Value = product.Price.ToString();
                doc.Save(filePath);
            }
        }

        
        public void DeleteProduct(string productId)
        {
            try
            {
                XDocument doc = XDocument.Load(filePath);
                var product = doc.Descendants("Product")
                    .FirstOrDefault(p => p.Element("ProductId").Value == productId);

                if (product != null)
                {
                    product.Remove();
                    doc.Save(filePath);
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (ví dụ: ghi log hoặc thông báo lỗi)
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }
        }

    }
}
