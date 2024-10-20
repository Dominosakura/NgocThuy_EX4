using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace NgocThuy_Lab4_4.Models
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "product.xml");


        public List<Catogory> GetAllCategories()
        {
            XDocument doc = XDocument.Load(filePath);
            return doc.Descendants("Category")
                .Select(c => new Catogory
                {
                    CategoryId = c.Attribute("CategoryId").Value,
                    CategoryName = c.Attribute("CategoryName").Value,
                    Products = c.Elements("Product").Select(p => new Product
                    {
                        ProductId = p.Element("ProductId").Value,
                        ProductName = p.Element("ProductName").Value,
                        Unit = p.Element("Unit").Value,
                        Price = decimal.Parse(p.Element("Price").Value)
                    }).ToList()
                }).ToList();
        }

        public List<Product> GetProductsByCategory(string categoryId)
        {
            var categories = GetAllCategories();
            return categories.FirstOrDefault(c => c.CategoryId == categoryId)?.Products;
        }

        public void AddCategory(Catogory category)
        {
            XDocument doc = XDocument.Load(filePath);
            doc.Root.Add(new XElement("Category",
                new XAttribute("CategoryId", category.CategoryId),
                new XAttribute("CategoryName", category.CategoryName),
                category.Products.Select(p => new XElement("Product",
                    new XElement("ProductId", p.ProductId),
                    new XElement("ProductName", p.ProductName),
                    new XElement("Unit", p.Unit),
                    new XElement("Price", p.Price)
                ))
            ));
            doc.Save(filePath);
        }

        public void UpdateCategory(Catogory category)
        {
            XDocument doc = XDocument.Load(filePath);
            var categoryElement = doc.Descendants("Category")
                .FirstOrDefault(c => c.Attribute("CategoryId").Value == category.CategoryId);

            if (categoryElement != null)
            {
                categoryElement.SetAttributeValue("CategoryName", category.CategoryName);
                categoryElement.Elements("Product").Remove();
                foreach (var product in category.Products)
                {
                    categoryElement.Add(new XElement("Product",
                        new XElement("ProductId", product.ProductId),
                        new XElement("ProductName", product.ProductName),
                        new XElement("Unit", product.Unit),
                        new XElement("Price", product.Price)
                    ));
                }
                doc.Save(filePath);
            }
        }

        public void DeleteCategory(string categoryId)
        {
            XDocument doc = XDocument.Load(filePath);
            var categoryElement = doc.Descendants("Category")
                .FirstOrDefault(c => c.Attribute("CategoryId").Value == categoryId);

            categoryElement?.Remove();
            doc.Save(filePath);
        }

        public void AddProduct(string categoryId, Product product)
        {
            XDocument doc = XDocument.Load(filePath);
            var categoryElement = doc.Descendants("Category")
                .FirstOrDefault(c => c.Attribute("CategoryId").Value == categoryId);

            if (categoryElement != null)
            {
                categoryElement.Add(new XElement("Product",
                    new XElement("ProductId", product.ProductId),
                    new XElement("ProductName", product.ProductName),
                    new XElement("Unit", product.Unit),
                    new XElement("Price", product.Price)
                ));
                doc.Save(filePath);
            }
        }

        public void UpdateProduct(Product product)
        {
            // Load the XML document
            XDocument doc = XDocument.Load(filePath);

            // Find the product element by ProductId
            var productElement = doc.Descendants("Product")
                .FirstOrDefault(p => p.Element("ProductId") != null &&
                                     p.Element("ProductId").Value == product.ProductId);

            if (productElement != null)
            {
                // Update the product details
                productElement.SetElementValue("ProductName", product.ProductName);
                productElement.SetElementValue("Unit", product.Unit);
                productElement.SetElementValue("Price", product.Price);

                // Save the updated XML document
                doc.Save(filePath);
            }
        }



        public Product GetProductById(string productId)
        {
            XDocument doc = XDocument.Load(filePath);
            var productElement = doc.Descendants("Product")
                .FirstOrDefault(p => p.Element("ProductId").Value == productId);

            if (productElement != null)
            {
                return new Product
                {
                    ProductId = productElement.Element("ProductId").Value,
                    ProductName = productElement.Element("ProductName").Value,
                    Unit = productElement.Element("Unit").Value,
                    Price = decimal.Parse(productElement.Element("Price").Value)
                };
            }

            return null; // Trả về null nếu không tìm thấy sản phẩm
        }

        public void DeleteProduct(string productId, string categoryId)
        {
            XDocument doc = XDocument.Load(filePath);

           
            var productElement = doc.Descendants("Product")
                .FirstOrDefault(p =>
                    p.Element("ProductId")?.Value == productId &&
                    p.Element("CategoryId")?.Value == categoryId); 

            if (productElement != null)
            {
                productElement.Remove();
                doc.Save(filePath); 
            }
        }


    }
}