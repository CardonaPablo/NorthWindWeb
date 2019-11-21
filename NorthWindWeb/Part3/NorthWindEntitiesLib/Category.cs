using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWindEntitiesLib
{
    public class Category
    {
        public int categoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
