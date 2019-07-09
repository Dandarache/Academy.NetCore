using System;
using System.Collections.Generic;

namespace EntityFrameworkChinook
{
    public partial class Manufacturers
    {
        public Manufacturers()
        {
            Products = new HashSet<Products>();
        }

        public int Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
