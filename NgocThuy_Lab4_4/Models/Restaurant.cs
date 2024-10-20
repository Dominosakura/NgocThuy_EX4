using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgocThuy_Lab4_4.Models
{
    public class Restaurant
    {
        public List<Catogory> Categories { get; set; }

        public Restaurant()
        {
            Categories = new List<Catogory>();
        }
    }
}