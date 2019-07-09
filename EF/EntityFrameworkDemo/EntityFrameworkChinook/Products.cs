using System;
using System.Collections.Generic;

namespace EntityFrameworkChinook
{
    public partial class Products
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Manufacturer { get; set; }

        public virtual Manufacturers ManufacturerNavigation { get; set; }
    }
}
