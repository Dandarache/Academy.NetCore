using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC01.Models
{
    public class ProductViewModel
    {
        public Product CurrentProduct { get; set; }

        public List<Product> Products { get; set; }
    }
}
