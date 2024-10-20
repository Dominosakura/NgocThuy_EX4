using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgocThuy_Lab4_4.Models
{
    public class Catogory
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }

        public Catogory()
        {
            Products = new List<Product>();
        }
       
    }
}