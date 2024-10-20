using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NgocThuy_Lab4_4.Models
{
    public class Image
    {
        public string ImagePath { get; set; }

        [Required]
        public string Description { get; set; }
    }
}